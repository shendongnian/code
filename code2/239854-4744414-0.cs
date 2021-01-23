    int[] original = { 1, 2, 3, 4 }, copy;
    byte[] bytes;
    using (var ms = new MemoryStream())
    {
        using (var writer = new BinaryWriter(ms))
        {
            writer.Write(original.Length);
            for (int i = 0; i < original.Length; i++)
                writer.Write(original[i]);
        }
        bytes = ms.ToArray();
    }
    using (var ms = new MemoryStream(bytes))
    using (var reader = new BinaryReader(ms))
    {
        int len = reader.ReadInt32();
        copy = new int[len];
        for (int i = 0; i < len; i++)
        {
            copy[i] = reader.ReadInt32();
        }
    }
