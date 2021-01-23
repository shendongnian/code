    // parse it
    var doc = new HtmlDocument();
    doc.LoadHtml(theHtml);
    // find the target elements
    var targets = doc.DocumentNode
                     .DescendantNodes()
                     .Where(n => n.NodeType == HtmlNodeType.Element
                              && n.Name.Equals("span", StringComparison.OrdinalIgnoreCase)
                              && !n.HasChildNodes && !n.HasAttributes)
                     .ToList(); // need a copy since the contents will change
    // replace them all
    foreach (var span in targets)
    {
        var br = HtmlNode.CreateNode("<br />");
        span.ParentNode.ReplaceChild(br, span);
    }
    // get back the html string
    using (StringWriter writer = new StringWriter())
    {
        doc.Save(writer);
        theHtml = writer.ToString();
    }
