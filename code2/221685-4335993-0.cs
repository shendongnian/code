    public static String TrimStart(this string inp, string chars)
    {
        while(chars.Contains(inp[0]))
        {
            inp = inp.Substring(1);
        }
    
        return inp;
    }
    
    public static String TrimEnd(this string inp, string chars)
    {
        while (chars.Contains(inp[inp.Length-1]))
        {
            inp = inp.Substring(0, inp.Length-1);
        }
    
        return inp;
    }
