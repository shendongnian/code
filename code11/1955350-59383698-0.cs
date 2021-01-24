    public static long Squeeze(float x, float y)
    {
        var lsb = BitConverter.GetBytes(x);
        var msb = BitConverter.GetBytes(y);
        return BitConverter.ToInt64(lsb.Concat(msb).ToArray(), 0);
    }
