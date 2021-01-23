    public static void SerializeRO(Stream stream, object ro)
    {
        byte[] allBytes;
        using (var serializedObjectStream = new MemoryStream())
        {
            var f = new BinaryFormatter();
            f.Serialize(serializedObjectStream, ro);
            allBytes = serializedObjectStream.ToArray();
        }
        var bw = new BinaryWriter(stream)
        bw.Write(allBytes.Length);
        bw.Write(allBytes);
    }
