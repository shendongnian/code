    //Implemented based on interface, not part of algorithm
    public string RemoveAllNamespaces(string xmlDocument)
    {
        return RemoveAllNamespaces(XElement.Parse(xmlDocument)).ToString();    
    }
    
    //Core recursion function
    private XElement RemoveAllNamespaces(XElement xmlDocument)
    {
        if (!xmlDocument.HasElements)
        {
            XElement xElement = new XElement(xmlDocument.Name.LocalName);
            xElement.Value = xmlDocument.Value;
            return xElement;
        }
        return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
    }
