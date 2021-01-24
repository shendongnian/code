    public static bool ContainsOnlyChars(string strValue, params char[] charValues)
    {
        if (string.IsNullOrEmpty(strValue))
            throw new ArgumentNullException("String cannot be null or empty.");
        var strLookup = strValue.ToLookup(c => c);
        for (int i = 0; i < charValues.Length; i++)
        {
            if (!strLookup.Contains(charValues[i]))
            {
                return false;
            }
        }
        return true;
    }
