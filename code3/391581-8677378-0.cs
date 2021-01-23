    public System.Xml.XmlElement GetSubElement(XmlElement Parent, string element)
    {
        System.Xml.XmlElement ret = null;
        if (Parent == null)
            return ret;
        XmlNodeList ContentNodes = Parent.GetElementsByTagName(element);
        if (ContentNodes.Count > 0)
        {
            XmlNode node = ContentNodes.Item(0);
            ret = (XmlElement)node;
        }
        return ret;
    }
