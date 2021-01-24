    public static bool IsUint32(string input)
    {
        uint result;
        return uint.TryParse(input, out result);
    }
