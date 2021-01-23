    XDocument xDoc = XDocument.Load("sitemap.xml");
    XNamespace ns = xDoc.Root.Name.Namespace;
    // Navigation within the xml 
    XElement urlset = xDoc.Element(ns + "urlset");
    Console.WriteLine(urlset.Name.LocalName);    // -> "urlset"
    IEnumerable<XElement> urls = urlset.Elements(ns + "url");
    foreach (var url in urls)
    {
        XElement loc = url.Element(ns + "loc");
        Console.WriteLine(loc.Value);    // -> "http://site.com/", ...                
    }
    // Inserting a new node under "urlset" node
    urlset.Add(
        new XElement(ns + "url",
            new XElement(ns + "loc",
                "http://site.com//questions/4183526")));
