    XNamespace ns = "http://www.ebay.com/marketplace/search/v1/services"
    XElement ack = doc.Root.Element(ns + "ack");
    XElement version = doc.Root.Element(ns + "version");
    IEnumerable<string> itemIds = doc.Root.Elements(ns + "searchResult")
                                          .Element(ns + "item")
                                          .Element(ns + "itemId")
                                          .Select(x => (string) x);
