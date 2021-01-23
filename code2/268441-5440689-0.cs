    public static XmlNode GetXmlNode(this XElement element)
    {
        using (XmlReader xmlReader = element.CreateReader())
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlReader);
            return xmlDoc;
        }
    }
