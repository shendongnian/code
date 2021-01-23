    #region Hexavigesimal (Excel Column Name to Number)
    public static int FromHexavigesimal(this string s)
    {
        int i = 0;
        s = s.Reverse();
        for (int p = s.Length - 1; p >= 0; p--)
        {
            char c = s[p];
            i += c.toInt() * (int)Math.Pow(26, p);
        }
    
        return i;
    }
    
    public static string ToHexavigesimal(this int i)
    {
        StringBuilder s = new StringBuilder();
    
        while (i > 26)
        {
            int r = i % 26;
            if (r == 0)
            {
                i -= 26;
                s.Insert(0, 'Z');
            }
            else
            {
                s.Insert(0, r.toChar());
            }
    
            i = i / 26;
        }
    
        return s.Insert(0, i.toChar()).ToString();
    }
    
    public static string Increment(this string s, int offset)
    {
        return (s.FromHexavigesimal() + offset).ToHexavigesimal();
    }
    
    private static char toChar(this int i)
    {
        return (char)(i + 64);
    }
    
    private static int toInt(this char c)
    {
        return (int)c - 64;
    }
    #endregion
