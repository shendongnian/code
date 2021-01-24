    HtmlDocument doc = new HtmlDocument();
    doc.Load(@"Path to html file");
    
    if (doc.DocumentNode.SelectNodes("//span") != null)
    {
        foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//span"))
        {
            var attributes = node.Attributes;
    
            foreach (var item in attributes)
            {
                if (item.Name.Equals("style") && item.Value.Contains("color:#000000;"))
                {
                    node.ParentNode.RemoveChild(node);
                }
            }
        }
    }
    
    string html = doc.DocumentNode.OuterHtml;
