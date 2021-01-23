    using (MemoryStream ms = new MemoryStream())
    {
        XmlWriterSettings xrs = new XmlWriterSettings();
        xrs.Encoding = Encoding.UTF8;
        using (XmlWriter writer = XmlWriter.Create(ms, xrs))
        {
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(writer, obj);
            writer.Flush();
        }
        using (StreamReader sr = new StreamReader(ms))
        {
            ms.Position = 0;
            xml = sr.ReadToEnd();
        }
    }
