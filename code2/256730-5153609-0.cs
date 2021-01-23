    public override XmlNode GetXml(XmlNode parentNode)
    {
        if (!Assigned) return null;
        XmlElement node = parentNode.OwnerDocument.CreateElement(Name);
        parentNode.AppendChild(node);
        node.InnerText = Value.ToString();
        node.IsEmpty = string.IsNullOrEmpty(node.InnerText);
        return node;
    }
