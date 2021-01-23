    static void Main()
    {
        var ns = new XmlSerializerNamespaces();
        ns.Add("", "http://www.sitemaps.org/schemas/sitemap/0.9");
        ns.Add("news", "http://www.google.com/schemas/sitemap-news/0.9");
        var ser = new XmlSerializer(typeof (GoogleSiteMap));
        var obj = new GoogleSiteMap {Urls = {
            new SiteUrl { Location = "http://www.example.org/business/article55.html", News = ""},
            new SiteUrl { Location = "http://www.example.org/business/page1.html", LastModified = new DateTime(2010,10,10),
            ChangeFrequency = "weekly"}
        }};
        ser.Serialize(Console.Out, obj, ns);
    }
}
    [XmlRoot("urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class GoogleSiteMap
    {
        private readonly List<SiteUrl> urls = new List<SiteUrl>();
        [XmlElement("url")]
        public List<SiteUrl> Urls { get { return urls; } }
    }
    
    public class SiteUrl
    {
        [XmlElement("loc")]
        public string Location { get; set; }
        [XmlElement("news", Namespace = "http://www.google.com/schemas/sitemap-news/0.9")]
        public string News { get; set; }
        [XmlElement("lastmod")]
        public DateTime? LastModified { get; set; }
        [XmlElement("changefreq")]
        public string ChangeFrequency { get; set; }
    
        public bool ShouldSerializeLastModified() { return LastModified.HasValue; }
    }
