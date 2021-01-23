    public static void SerializeRO(Stream stream, object ro)
    {
        MemoryStream serializedObjectStream = new MemoryStream();
        var f = new BinaryFormatter();
        f.Serialize(serializedObjectStream, ro);
        MemoryStream writeStream = new MemoryStream();
        BinaryWriter bw = new BinaryWriter(writeStream);
        bw.Write(serializedObjectStream.Length);
        serializedObjectStream.Seek(0, SeekOrigin.Begin);
        serializedObjectStream.WriteTo(writeStream);
        var bytes = writeStream.ToArray();
        stream.Write(bytes, 0, bytes.Length);
        bw.Close();
    }
