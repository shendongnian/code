    XmlSerializerNamespaces ns = new XmlSerializerNamespaces(); ns.Add("", "");
    using (XmlWriter writer = XmlWriter.Create(Console.Out, new XmlWriterSettings { OmitXmlDeclaration = true}))
    {
      new XmlSerializer(typeof (SomeType)).Serialize(writer, new SomeType(), ns);
    }
