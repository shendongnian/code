    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.Load("path to your HTML document");
    StringBuilder content = new StringBuilder();
    foreach (var node in doc.DocumentNode.DescendantNodesAndSelf())
    {
        if (!node.HasChildNodes)
        {
            sb.AppendLine(node.InnerText);
        }
    }
