    using(var writer = new XmlTextWriter(@"C:\MyXmlFile.xml", null))
    {
        writer.WriteStartElement("someString");
        writer.WriteText("This is < a > string & everything will get encoded");
        writer.WriteEndElement();
    }
