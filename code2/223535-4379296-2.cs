    var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };
    var namespaces = new XmlSerializerNamespaces();
    namespaces.Add(string.Empty, string.Empty);
    
    using (var writer = XmlWriter.Create(file, settings))
    {
    	XmlSerializer serializer = new XmlSerializer(source.GetType());
    	serializer.Serialize(writer, source, namespaces);
    }
