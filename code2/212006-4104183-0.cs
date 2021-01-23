    string html;
    using (var client = new WebClient()) {
        html = client.DownloadString("http://stackoverflow.com");
    }
    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    HtmlNode node;
    // loop this way to avoid issues with nesting, mutating the set, etc
    while((node = doc.DocumentNode.SelectSingleNode("//a")) != null) {
        var span = doc.CreateElement("span");
        span.InnerHtml = node.InnerHtml;
        node.ParentNode.InsertAfter(span, node);
        node.Remove();
    }
    string final = doc.DocumentNode.OuterHtml;
