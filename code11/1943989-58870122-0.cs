        static void Main(string[] args)
        {            
            var client = new System.Net.Http.HttpClient();
            var content = client.GetStringAsync(@"https://www.w3schools.com/html/html5_video.asp").Result;
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(content);
            // Change the accessor from "id" to the attribute you want the value for
            var  videos = document.DocumentNode.Descendants("video").FirstOrDefault().Attributes["id"].Value;            
        }
