    public static string FloatToHex(float val)
    {
        var bytes = BitConverter.GetBytes(val);
        return BitConverter.ToString(bytes).Replace("-", string.Empty);
    }
