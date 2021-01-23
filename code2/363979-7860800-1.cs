    static string SortAttributes(string xml)
    {
        var doc = XDocument.Parse(xml);
        foreach (XElement element in doc.Descendants())
        {
            var attrs = element.Attributes().ToList();
            attrs.Remove();
            attrs.Sort((a, b) => a.Name.LocalName.CompareTo(b.Name.LocalName));
            element.Add(attrs);
        }
        xml = doc.ToString();
        return xml;
    }
