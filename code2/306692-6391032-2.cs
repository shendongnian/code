    static byte[] ParseAsBytes(static string s)
    {
        return Enumerable.Range(0, s.Length / 2)
                         .Select(i => byte.Parse(s.Substring(i * 2, 2), 
                                                 NumberStyles.AllowHexSpecifier))
                         .ToArray();
    }
    static string ToHexString(this byte[] buffer)
    {
        return string.Concat(buffer.Select(i => i.ToString("X2")));
    }
