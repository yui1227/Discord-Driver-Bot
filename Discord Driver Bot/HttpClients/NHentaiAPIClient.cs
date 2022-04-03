﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Discord_Driver_Bot.HttpClients.NHentai
{
    public class NHentaiAPIClient
    {
        HttpClient Client;
        public NHentaiAPIClient()
        {
            Client = new HttpClient();
        }

        public async Task<Gallery> GetGalleryAsync(string id)
        {
            try
            {
                string json = await Client.GetStringAsync($"https://nhentai.net/api/gallery/{id}");
                if (json.Contains("error")) return null;

                return JsonConvert.DeserializeObject<Gallery>(json);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public class Gallery
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("media_id")]
        public long MediaId { get; set; }

        [JsonProperty("title")]
        public Title Title { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("scanlator")]
        public string Scanlator { get; set; }

        [JsonProperty("upload_date")]
        public long UploadDate { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        [JsonProperty("num_pages")]
        public long NumPages { get; set; }

        [JsonProperty("num_favorites")]
        public long NumFavorites { get; set; }
    }

    public class Images
    {
        [JsonProperty("pages")]
        public List<Cover> Pages { get; set; }

        [JsonProperty("cover")]
        public Cover Cover { get; set; }

        [JsonProperty("thumbnail")]
        public Cover Thumbnail { get; set; }
    }

    public class Cover
    {
        [JsonProperty("t")]
        public string T { get; set; }

        [JsonProperty("w")]
        public long W { get; set; }

        [JsonProperty("h")]
        public long H { get; set; }
    }

    public partial class Tag
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }
    }

    public class Title
    {
        [JsonProperty("english")]
        public string English { get; set; }

        [JsonProperty("japanese")]
        public string Japanese { get; set; }

        [JsonProperty("pretty")]
        public string Pretty { get; set; }
    }
}
