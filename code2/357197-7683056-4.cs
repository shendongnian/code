    public static byte[] GetBytes<T>(T value)
    {
        // TODO: validation and caching as necessary
        var writer = CreateWriter(value);
        var memory = new MemoryStream();
        writer(new BinaryWriter(memory), value);
        return memory.ToArray();
    }
