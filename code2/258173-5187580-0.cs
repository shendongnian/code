    string site = webKitBrowser1.Url.Scheme + "://" + webKitBrowser1.Url.Authority;
    WebKit.DOM.Document doc = webKitBrowser1.Document;
    WebKit.DOM.NodeList links = doc.GetElementsByTagName("link");
    WebKit.DOM.Element link;
    string editlink = "none";
    foreach (var item in links)
    {
        link = (WebKit.DOM.Element)item;
        if (link.Attributes["rel"].NodeValue == "edit") { editlink = link.Attributes["href"].NodeValue; }
    }
    if (editlink != "none") { webKitBrowser2.Navigate(site + editlink); }
