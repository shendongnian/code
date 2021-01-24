    public class Company
    {
        [JsonProperty(Order = 0)]
        public string CompanyName { get; set; }
        [JsonProperty(Order = 1)]
        public double IPO { get; set; }
        [JsonProperty(Order = 2)]
        public string Category { get; set; }
        [JsonProperty(Order = 3)]
        public string Description { get; set; }
        [JsonProperty(Order = 4)]
        public int StartDate { get; set; }
        [JsonProperty(Order = 5)]
        public List<Product> Products = new List<Product>();
        [JsonProperty(Order = 6)]
        public List<NewsArticle> CompanySpecificNewsArticles = new List<NewsArticle>();
        [JsonProperty(Order = 7)]
        public List<string> EavesDropperList = new List<string>();
    }
