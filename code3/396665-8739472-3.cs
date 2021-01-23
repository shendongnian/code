    public static string CheckAttr(XmlAttribute attr) 
    {
        return attr == null ? "" : attr.Value.Trim();
    }
    public static string CheckNode(XmlNode node) 
    {
        return node == null ? "" : node.InnerText.Trim();
    }
