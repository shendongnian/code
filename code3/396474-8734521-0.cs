    private byte[] ToByteArray(object source)
    {
        var formatter = new BinaryFormatter();
        using (var stream = new MemoryStream())
        {
            formatter.Serialize(stream, source);                
            return stream.ToArray();
        }
    }
