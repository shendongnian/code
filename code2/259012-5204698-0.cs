    using System;
    using System.IO;
    using System.Net;
    using System.Xml;
    using Sgml;
    
    class Program
    {
        static void Main()
        {
            var url = "http://www.stackoverflow.com";
            using (var reader = new SgmlReader())
            using (var client = new WebClient())
            using (var streamReader = new StreamReader(client.OpenRead(url)))
            {
                reader.DocType = "HTML";
                reader.WhitespaceHandling = WhitespaceHandling.All;
                reader.CaseFolding = Sgml.CaseFolding.ToLower;
                reader.InputStream = streamReader;
    
                var doc = new XmlDocument();
                doc.PreserveWhitespace = true;
                doc.XmlResolver = null;
                doc.Load(reader);
                var title = doc.SelectSingleNode("//title");
                if (title != null)
                {
                    Console.WriteLine(title.InnerText);
                }
            }
        }
    }
