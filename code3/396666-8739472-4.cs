    public static string CheckAttr(this XmlNode, string attrName)
    {
        return attrName[attrName] == null ? "" : attrName[attrName].Value.Trim();
    }
    public static string CheckNode(this XmlNode, string nodeName)
    {
        return node.SelectSingleNode(nodeName) == null ? 
                     "" : 
                     node.SelectSingleNode(nodeName).InnerText.Trim();
    }
