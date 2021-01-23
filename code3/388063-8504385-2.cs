    /// <summary>
    /// Gets a first different char occurence index
    /// </summary>
    /// <param name="a">First string</param>
    /// <param name="b">Second string</param>
    /// <returns>
    /// Returns first difference index or -1 if no difference is found
    /// </returns>
    public static int GetBreakIndex(string a, string b)
    {
        int equalsReturnCode = -1;
        if (a.Equals(b))
        {
            return equalsReturnCode;
        }
    
        string longest = b.Length > a.Length ? b : a;
        string shorten = b.Length > a.Length ? a : b;    
        for (int i = 0; i < shorten.Length; i++)
        {
            if (shorten[i] != longest[i])
            {
                return i;
            }
        }
        // This allows handle cases like a="1234", b="123"
        // so index=3 woudl be returned, if you do not need such behaviour
        // just remove this
        if (a.Length != b.Length)
        {
            return shorten.Length;
        }
    
        return equalsReturnCode;
    }
