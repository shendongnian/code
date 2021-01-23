    using System;
    using System.Net;
    using HtmlAgilityPack;
    
    class Program
    {
        static void Main()
        {
            string html = "";
            using (var client = new WebClient())
            {
                html = client.DownloadString("http://stackoverflow.com");
            }
    
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            foreach(HtmlNode link in doc.DocumentNode.SelectNodes("//a"))
            {
                // Will print all text contained inside all anchors 
                // on http://stackoverflow.com
                Console.WriteLine(link.InnerText);
            }
        }
    }
