    using (var mem = new MemoryStream())  
    using (var writer = new XmlTextWriter(mem, System.Text.Encoding.UTF8))
    {
        writer.Formatting = Formatting.Indented;
        doc.WriteTo(writer);
        writer.Flush();
        mem.Flush();
        mem.Seek(0, SeekOrigin.Begin);
        using (var reader = new StreamReader(mem))
        {
            var xml = reader.ReadToEnd();
            Console.WriteLine(xml);
        }
    }
