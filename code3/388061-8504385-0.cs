    /// <summary>
    /// Gets a first different char occurence index
    /// </summary>
    /// <param name="a">First string</param>
    /// <param name="b">Second string</param>
    /// <returns>Returns first difference idnex or -1 if no difference is found</returns>
    public static int GetBreakIndex(string a, string b)
    {
        int equalsReturnCode = -1;
        if (a.Equals(b))
        {
            return equalsReturnCode;
        }
    
        string longest = a;
        string shorten = b;
                
        if( b.Length > a.Length)
        {
            longest = b;
            shorten = a;
        }
    
        for (int i = 0; i <= shorten.Length; i++)
        {
            if (shorten[i] != longest[i])
            {
                return i;
            }
        }
    
        return equalsReturnCode;
    }
