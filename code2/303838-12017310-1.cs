    public static byte[] Create<T>(T value)
    {
        var serializer = new DataContractJsonSerializer(typeof (T));
        using (var stream = new MemoryStream())
        {
            serializer.WriteObject(stream, value);
            return stream.ToArray();
        }
    }
