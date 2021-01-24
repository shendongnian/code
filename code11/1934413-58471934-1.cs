        public class Source
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
    public class Article
    {
        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
        [JsonProperty(PropertyName = "urlToImage")]
        public string UtlToImage { get; set; }
        [JsonProperty(PropertyName = "publishedAt")]
        public string PublishedAt { get; set; }
        [JsonProperty(PropertyName = "content")]
        public string Content { get;set; }
    }
    public class  ResultJson
    {
        public List<Source> Sources { get; set; }
        public List<Article> Articles { get; set; }
    }
    public class Programm 
    {
            var json = new WebClient().DownloadString(url);
            var articles = JsonConvert.DeserializeObject<ResultJson>(json).Articles.ToList();
            List<string> allUrls = new List<string>();
            allUrls = articles.Select(u => u.Url).ToList();
    }
