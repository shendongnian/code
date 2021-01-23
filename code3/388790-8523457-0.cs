    public static string[] SplitLength(this string val, int length)
    {
        var parts = new List<string>();
        for(int i = 0; i < val.Length; i += length)
        {
            parts.Add(val.Substring(i * length, length));
        }
        return parts.ToArray();
    }
