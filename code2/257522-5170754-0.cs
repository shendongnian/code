    XmlWriterSettings settings = new XmlWriterSettings();
    settings.OmitXmlDeclaration = true;
    settings.Indent = true;
    using (XmlWriter writer = XmlWriter.Create(file, settings))
    {
        XmlSerializer serializer = new XmlSerializer(source.GetType());
        XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
        namespaces.Add(string.Empty, string.Empty);
        // ...
    }
