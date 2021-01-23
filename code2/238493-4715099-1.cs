    using System.Text;
    using System.Xml;
    public string GetImmediateInnerText(XmlNode node)
    {
        StringBuilder builder = new StringBuilder();
        foreach (XmlNode child in node.ChildNodes) {
            if (child.NodeType == XmlNodeType.Text) {
                builder.Append(child.Value);
            }
        }
        return builder.ToString();
    }
