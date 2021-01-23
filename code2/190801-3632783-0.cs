    using (MemoryStream memoryStream = new MemoryStream())
    {
        serializer.Serialize(memoryStream, this);
        memoryStream.Seek(0, SeekOrigin.Begin);
        using (StreamReader reader = new StreamReader(memoryStream))
        {
            return reader.ReadToEnd();
        }
    }
