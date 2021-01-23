    var settings = new XmlReaderSettings
    {
        NameTable = new NameTable(),
    };
    XmlNamespaceManager xmlns = new XmlNamespaceManager(settings.NameTable);
    xmlns.AddNamespace("yourundeclarednamespace", "http://www.dummynamespace.org");
    XmlParserContext context = new XmlParserContext(null, xmlns, "", XmlSpace.Default);
    using (var reader = XmlReader.Create(filePath, settings, context))
    {
    }
