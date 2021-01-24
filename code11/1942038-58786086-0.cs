    public static bool ContainsOnlyChars(string strValue, params char[] charValues)
    {
        if (string.IsNullOrEmpty(strValue))
            throw new ArgumentNullException("String cannot be null or empty.");
        // The O(n) part
        var dic = new Dictionary<char, bool>();
        foreach (var ch in strValue)
            if (!dic.ContainsKey(ch))
                dic.Add(ch,1);
        // The O(m) part
        foreach (var ch in charValues)
            if(!dic.ContainsKey(ch))
                return false;
        return true;
    }
