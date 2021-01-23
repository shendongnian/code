    using (WebClient client = new WebClient())
    using (var read = client.OpenRead("http://your.com"))
    {
        HtmlDocument doc = new HtmlDocument();
        doc.Load(read, true); // true = get encoding from byte order masks
        // process doc, extract title
        var title = doc.DocumentNode.SelectSingleNode("//title").InnerText;
    }
