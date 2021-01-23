    String xmlString =
        @"<Entity>
            <aaa />
        </Entity>";
    
    using (XmlReader reader = XmlReader.Create(new StringReader(xmlString)))
    {
        XmlDocument tmpDoc = new XmlDocument();
        XmlNode a = tmpDoc.ReadNode(reader);
        tmpDoc.AppendChild(a);
        var t1 = tmpDoc.GetElementsByTagName("Entity")[0];
        XmlNode mainNode = tmpDoc.SelectSingleNode("//Entity");
    }
