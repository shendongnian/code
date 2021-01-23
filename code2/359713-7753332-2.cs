    static class Program
    {
        static void Main()
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "http://www.sitemaps.org/schemas/sitemap/0.9");
            ns.Add("news", "http://www.google.com/schemas/sitemap-news/0.9");
            var ser = new XmlSerializer(typeof (GoogleSiteMap));
            var obj = new GoogleSiteMap {Urls = new List<string> {"abc", "def", "ghi"}};
            ser.Serialize(Console.Out, obj, ns);
        }
    }
    
    [XmlRoot("urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class GoogleSiteMap
    {
    
        [XmlElement("url", Namespace = "http://www.google.com/schemas/sitemap-news/0.9")]
        public List<string> Urls { get; set; }
    }
