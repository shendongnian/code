        private string stripTags(string html)
        {
            var output = new StringBuilder();
            HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//*"))
            {
                output.AppendLine(node.InnerText + Environment.NewLine);
            }
            return output.ToString();
        }
