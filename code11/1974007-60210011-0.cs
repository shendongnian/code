    XmlSerializer serializer = new XmlSerializer(typeof(MyClass));
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add("example", "http://www.w3.org");
    using (StreamWriter writer = new StreamWriter(xmlFilePath))
    {
        serializer.Serialize(writer, myClassInstance, ns);
    }
