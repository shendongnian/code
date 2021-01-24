    List<XElement> p = xdoc.Descendants("p").ToList();
    for (int i = p.Count - 1; i >= 0; i--)
    {
        var newP = new XElement("p");
        newP.ReplaceAttributes(p[i].Attributes());
                    
        foreach (var node in p.Nodes())
        {
            if (node.NodeType == System.Xml.XmlNodeType.Element && ((XElement)node).Name == "br")
            {
                p[i].AddBeforeSelf(newP);
                newP = new XElement("p");
                newP.ReplaceAttributes(p[i].Attributes());
            }
            else
            {
                newP.Add(node);
            }
        }
        p[i].AddBeforeSelf(newP);
        p[i].Remove();
    }
