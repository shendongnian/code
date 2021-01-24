    public static Int16 Parse(this BinaryReader reader, int index)
    {
        reader.Seek(index, SeekOrigin.Begin);
        return reader.ReadInt16();
    }
