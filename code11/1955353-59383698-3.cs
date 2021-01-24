    public static void Unpack(long value, out float x, out float y)
    {
        var bytes = BitConverter.GetBytes(value);
        x = BitConverter.ToSingle(bytes, 0);
        y = BitConverter.ToSingle(bytes, 4);
    }
