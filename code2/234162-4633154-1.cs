    XmlDocument rssDoc = new XmlDocument();
    rssDoc.Load(rssStream);
    
    XmlNamespaceManager nsmgr = new XmlNamespaceManager(rssDoc.NameTable);
    nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
    
    XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");
    for (int i = 0; i < 5; i++) {
        XmlNode rssDetail = rssItems[i].SelectSingleNode("dc:creator", nsmgr);
        if (rssDetail != null) {
            user = rssDetail.InnerText;
        } else {
            user = "";
        }
    }
