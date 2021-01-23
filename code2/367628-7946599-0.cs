    XmlSerializer serializer = new XmlSerializer(dict.GetType());
    var settings = new XmlWriterSettings { Indent = false };
    using (var stream = new MemoryStream())
    using (var writer = XmlWriter.Create(stream, settings))
    {
        serializer.Serialize(writer, dict);
        string r2 = Encoding.UTF8.GetString(stream.ToArray());
    }
