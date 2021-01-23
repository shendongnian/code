    /// <summary>
    /// Gets a first different char occurence index
    /// </summary>
    /// <param name="a">First string</param>
    /// <param name="b">Second string</param>
    /// <param name="handleLengthDifference">
    /// If true will return index of first occurence even strings are of different length
    /// and same-length parts are equals otherwise -1
    /// </param>
    /// <returns>
    /// Returns first difference index or -1 if no difference is found
    /// </returns>
    public int GetFirstBreakIndex(string a, string b, bool handleLengthDifference)
    {
        int equalsReturnCode = -1;
        if (String.IsNullOrEmpty(a) || String.IsNullOrEmpty(b))
        {
            return handleLengthDifference ? 0 : equalsReturnCode;
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
    
        // Handles cases when length is different (a="1234", b="123")
        // index=3 would be returned for this case
        // If you do not need such behaviour - just remove this
        if (handleLengthDifference && a.Length != b.Length)
        {
            return shorten.Length;
        }
        
        return equalsReturnCode;
    }
