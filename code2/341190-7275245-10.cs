    public static void SerializeRO(Stream stream, object ro)
    {
        MemoryStream serializedObjectStream = new MemoryStream();
        var f = new BinaryFormatter();
        f.Serialize(serializedObjectStream, ro);
        MemoryStream writeStream = new MemoryStream();
        BinaryWriter bw = new BinaryWriter(writeStream);
        var bytes = serializedObjectStream.ToArray();
        bw.Write(bytes.Length);
        bw.Write(bytes);
        var bwBytes = writeStream.ToArray();
        stream.Write(bwBytes, 0, bwBytes.Length);
        bw.Close();
    }
