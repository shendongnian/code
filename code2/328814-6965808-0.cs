    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main(string[] args)
        {
            string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
        <urlset>    
            <url>
                <loc>element1</loc>
                <changefreq>daily</changefreq>
                <priority>0.2</priority>
            </url>
            <url>
                <loc>element2</loc>
                <changefreq>daily</changefreq>
                <priority>0.2</priority>
            </url>
        </urlset>";
            
            XDocument doc = XDocument.Parse(xml);
            List<string> urlList = doc.Root
                                      .Elements("url")
                                      .Elements("loc")
                                      .Select(x => (string) x)
                                      .ToList();
            Console.WriteLine(urlList.Count);
        }
    }
