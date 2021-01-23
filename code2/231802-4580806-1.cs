    using (var writer = XmlWriter.Create("foo.xml"))
    {
        writer.WriteStartDocument();
        SiblingGenerator(XMLList, writer, newPath, fi);
        SiblingGenerator(XMLList, writer, newPath, fi);
        ...
        writer.WriteEndDocument();
    }
