    class Program
    {
        static void Main()
        {
            using (var reader = new SgmlReader())
            {
                reader.DocType = "HTML";
                reader.Href = "http://www.microsoft.com";
                var doc = new XmlDocument();
                doc.Load(reader);
                var anchors = doc.SelectNodes("//a/@href");
                foreach (XmlAttribute href in anchors)
                {
                    using (var client = new WebClient())
                    {
                        var data = client.DownloadData(href.Value);
                        // TODO: do something with the downloaded data
                    }
                }
            }
        }
    }
