    public XmlDocument GetEntityXml<T>(List<T> listToSave)
    {
        XmlDocument xmlDoc = new XmlDocument();
        XPathNavigator nav = xmlDoc.CreateNavigator();
        using (XmlWriter writer = nav.AppendChild())
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("Whatever you need"));
            ser.Serialize(writer, listToSave);
        }
        return xmlDoc;
    }
