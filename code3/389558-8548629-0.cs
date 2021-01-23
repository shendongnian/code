    public string StripHTMLTags(string str)
            {
                if (String.IsNullOrEmpty(str))
                {
                    return null;
                }
    
                StringBuilder pureText = new StringBuilder();
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(str);
    
                foreach (HtmlNode node in doc.DocumentNode.ChildNodes)
                {
                    pureText.Append(node.InnerText);
                }
    
                return pureText.ToString();
            }
