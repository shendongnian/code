        private void stripTags(string html)
        {
            var output = new StringBuilder();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.Load("file.html");
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//*"))
            {
                output.AppendLine(node.InnerText.ToString() + "\n");
                dumpBox.Text = output.ToString();
            }
        }
