    var settings = new XmlWriterSettings
    {
        Indent = True,
        IndentChars = "    ",
        Encoding = Encoding.UTF8
    };
    using (var stream = new MemoryStream())
    using (var writer = XmlWriter.Create(stream, settings))
    {
        writer.WriteStartDocument();
        // ...
    }
