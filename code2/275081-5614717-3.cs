    string text = "";
    HtmlWeb web = new HtmlWeb();
    string url = string.Format("http://caps.fool.com/Ticker/{0}.aspx", ticker);
    HtmlAgilityPack.HtmlDocument doc = web.Load(url);
    var node = doc.DocumentNode.SelectSingleNode("//h1[@class='subHead']");
    text = node.FirstChild.InnerText.Trim();
    return text;
