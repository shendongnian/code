    XDocument data = XDocument.Load(xmlReader);
    IEnumerable<XNode> nodes = null;
    nodes = data.Descendants(XName.Get("Results", IMAGE_NS)).Nodes();
    if (nodes.Count() > 0)
    {
        var results = from uris in nodes
        select new LiveSearchResultImage
        {
        URI =
        ((XElement)uris).Element(XName.Get("Url", IMAGE_NS)).Value,
        Title =
        ((XElement)uris).Element(XName.Get("Title", IMAGE_NS)).Value,
        ThumbnailURI =
        ((XElement)uris).Element(XName.Get("Thumbnail", IMAGE_NS)).Value,
        };
        return results;
    }
