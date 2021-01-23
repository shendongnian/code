    var serializer = new XmlSerializer(typeof(SomeSerializableObject));
    string utf8;
    using (StringWriter writer = new Utf8StringWriter())
    {
        serializer.Serialize(writer, entry);
        utf8 = writer.ToString();
    }
