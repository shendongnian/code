    using (MemoryStream memoryStream = new MemoryStream())
    {
        using (var xmlWriter = new MyXmlTextWriter(memoryStream, new UTF8Encoding(false)))
        {                    
            serializer.Serialize(xmlWriter, value);
        }
        return Encoding.UTF8.GetString(memoryStream.ToArray());
    }
