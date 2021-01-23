    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.Load("test.html");
    var nodes = doc.DocumentNode.SelectNodes("/h1[@class='subHead']");
    foreach (var node in nodes)
    {
        string text = node.FirstChild.InnerText; //output: "Microsoft Corp"
        string textAll = node.InnerText; //output: "Microsoft Corp (NASDAQ:MSFT)"
    }
