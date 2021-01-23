    static byte[] ParseAsBytes(static string s)
    {
        var result = new byte[s.Length / 2];
        for (int i = 0; i < result.Length; i++)
        {
            result[i] = byte.Parse(s.Substring(i * 2, 2),
                                   NumberStyles.AllowHexSpecifier);
        }
        return result;
    }
    static string ToHexString(this byte[] buffer)
    {
        return string.Concat(buffer.Select(i => i.ToString("X2")));
    }
