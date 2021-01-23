    var settings = new XmlWriterSettings
    {
        Encoding = Encoding.GetEncoding(1252)
    };
    
    using (var buffer = new MemoryStream())
    {
        using (var writer = XmlWriter.Create(buffer, settings))
        {
            writer.WriteRaw("<sample></sample>");
        }
    
        buffer.Position = 0;
    
        using (var reader = new StreamReader(buffer))
        {
            Console.WriteLine(reader.ReadToEnd());
            Console.Read();
        }
    }
