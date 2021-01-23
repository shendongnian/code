    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add(string.Empty, string.Empty);
    ns.Add(string.Empty, "Com.Foo.Request");
    Serializer.Serialize(xmlWriter, this, ns);
 
