    example: to Generate Clear XML without namespace
    
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add("", "");
    
    XmlSerializer serializer = new XmlSerializer(typeof(object));
    StringWriter stringWriter = new StringWriter();
    using(XmlWriter writer = new XmlTextWriterFormattedNoDeclaration(stringWriter ))
    {
        serializer.Serialize(writer, this, ns);
    }
    string xmlText = stringWriter.ToString();
