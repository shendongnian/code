    static int Main(string[] args)
    {
        XmlDocument xDoc = new XmlDocument();
        xDoc.LoadXml("<Grid><Label /><Label /><Label /></Grid>");
        Response.Write(GetAllChildrenOfName(xDoc.FirstChild, "Label").Count.ToString());
    }
    public XmlNodeList GetAllChildrenOfName(XmlNode parent, string childName)
    {
        string xpath = childName;
        return parent.SelectNodes(xpath);
    }
