    using System.Xml;
    ..
    static void Main(string[] args)
    {
        XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
        xmlWriterSettings.Indent = true;
        xmlWriterSettings.IndentChars = ("\t");
        xmlWriterSettings.OmitXmlDeclaration = true;
        XmlWriter writer = XmlWriter.Create("example.xml", xmlWriterSettings);
        
        writer.WriteStartElement("root");
        writer.WriteStartElement("element1");
        writer.WriteEndElement();
        writer.WriteStartElement("element2");
        writer.WriteFullEndElement();
        writer.WriteEndElement();
        writer.WriteEndDocument();
        writer.Close();
    }
