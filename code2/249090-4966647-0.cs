    using (MemoryStream stream = new MemoryStream())
    {
        using (BinaryWriter writer = new BinaryWriter(stream))
        {
            writer.Write(2);
            writer.Write((short) 3);
            writer.Write((short) 3);
            writer.Write(4.4f);
            writer.Write(5.6f);
        }
        byte[] bytes = stream.ToArray();
    }
