    public static byte[] SerializeToBytes<T>(T original)
    {
        byte[] results;
        using (MemoryStream stream = new MemoryStream())
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, original);
            stream.Seek(0, SeekOrigin.Begin);
            results = stream.ToArray();
        }
        return results;
    }
