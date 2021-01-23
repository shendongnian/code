    public static void SortXml(XElement node)
    {
        node.ReplaceNodes(node.Elements("Node")
            .OrderBy(x => (string)x.Attribute("leaf"))
            .ThenBy(x => (string)x.Attribute("title")));
        foreach (var childNode in node.Elements("Node"))
            SortXml(childNode);
    }
    ...
    XDocument doc = XDocument.Load("test.xml");
    SortXml(doc.Root);
