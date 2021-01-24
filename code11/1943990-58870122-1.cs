        static void Main(string[] args)
        {            
            var client = new System.Net.Http.HttpClient();
            var content = client.GetStringAsync(@"https://www.w3schools.com/html/html5_video.asp").Result;
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(content);            
            var  videos = document.DocumentNode.Descendants("video").FirstOrDefault().Attributes["src"].Value;            
        }
