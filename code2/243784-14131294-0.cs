        private List<string> ParseLinks(string html)
        {
            HtmlDocument doc = new HtmlDocument(); 
            doc.LoadHtml(html);
            return doc.DocumentNode.SelectNodes("//a[@href]").ToList().ConvertAll(r => r.Attributes.ToList().ConvertAll(i => i.Value)).SelectMany(j => j).ToList();
        }
