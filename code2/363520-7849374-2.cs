    var xmlSerializer = new XmlSerializer(typeof(House));
    using (var memoryStream = new MemoryStream())
    {
        xmlSerializer.Serialize(memoryStream, newHouse);
        memoryStream.Position = 0;
        tcpClient.GetStream().Write(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
    }
