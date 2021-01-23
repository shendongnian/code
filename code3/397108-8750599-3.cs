    XDocument SortXml(XDocument xDoc)
    {
        Func<XElement, string> keyBuilder = 
            s =>
            {
                var parts = s.Name.ToString().Split('.');
                if (parts.Length < 2)
                    return parts[0];
                else
                {
                    int i=0;
                    string parts1 = parts[1];
                    if (Int32.TryParse(parts[1], out i)) parts1 = i.ToString("X8");
                    return parts[0] + parts1;
                }
            };
        XElement root = new XElement(xDoc.Root.Name);
        SortXml(root, xDoc.Elements(), keyBuilder);
        return new XDocument(root);
    }
    void SortXml(XElement newXDoc, IEnumerable<XElement> elems, Func<XElement, string> keyBuilder)
    {
        foreach (var newElem in elems.OrderBy(e => keyBuilder(e)))
        {
            XElement t = new XElement(newElem);
            t.RemoveNodes();
            newXDoc.Add(t);
            SortXml(t, newElem.Elements(), keyBuilder);
        }
    }
