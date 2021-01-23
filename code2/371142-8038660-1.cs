    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using HtmlAgilityPack;
    
    class Program
    {
        static void Main()
        {
            using (var client = new WebClient())
            {
                var htmlSource = client.DownloadString("http://www.stackoverflow.com");
                foreach (var item in GetLinksFromWebsite(htmlSource))
                {
                    // TODO: you could easily write a recursive function
                    // that will call itself here and retrieve the respective contents
                    // of the site ...
                    Console.WriteLine(item);
                }
            }
        }
    
        public static List<String> GetLinksFromWebsite(string htmlSource)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(htmlSource);
            return doc
                .DocumentNode
                .SelectNodes("//a[@href]")
                .Select(node => node.Attributes["href"].Value)
                .ToList();
        }
    }
