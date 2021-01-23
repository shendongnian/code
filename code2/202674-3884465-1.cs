    class Program
    {
        static void Main()
        {
            using (var reader = new SgmlReader())
            {
                reader.Href = "http://www.microsoft.com";
                var doc = new XmlDocument();
                doc.Load(reader);
                var nodes = doc.SelectNodes("//*[contains(text(), 'Products')]");
                foreach (XmlNode node in nodes)
                {
                    Console.WriteLine(node.OuterXml);
                }
            }
        }
    }
