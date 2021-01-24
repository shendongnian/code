    public static long Squeeze(float x, float y)
    {
        var bytes = new byte[8];
        BitConverter.GetBytes(x).CopyTo(bytes, 0);
        BitConverter.GetBytes(y).CopyTo(bytes, 4);
        return BitConverter.ToInt64(bytes, 0);
    }
