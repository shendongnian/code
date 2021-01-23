    public static XElement EnsureNamespaceExists(this XElement xElement, XNamespace xNamespace)
    {
        string nodeName = xElement.Name.LocalName;
    
        if (!xElement.HasAttribute("xmlns"))
        {
            foreach (XElement tmpElement in xElement.DescendantsAndSelf())
            {
                tmpElement.Name = xNamespace + tmpElement.Name.LocalName;
            }
            xElement = new XElement(xNamespace + nodeName, xElement.FirstNode);
        }
    
        return xElement;
    }
