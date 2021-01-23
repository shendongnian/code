    XmlSerializer serializer = new XmlSerializer(typeof(object));
    StringWriter stringWriter = new StringWriter();
    using (XmlWriter writer = XmlWriter.Create(stringWriter, new XmlWriterSettings() { OmitXmlDeclaration = true }))
    {
        serializer.Serialize(writer, this, new XmlSerializerNamespaces() { "",""});
    }
    string xmlText = stringWriter.ToString();
