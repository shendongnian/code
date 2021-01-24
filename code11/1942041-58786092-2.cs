    public static bool ContainsOnlyChars(string strValue, params char[] charValues)
    {
        if (string.IsNullOrEmpty(strValue))
            throw new ArgumentNullException("String cannot be null or empty.");
        var chrLookup = charValues.ToLookup(c => c);
        for (int i = 0; i < strValue.Length; i++)
        {
            if (!chrLookup.Contains(strValue[i]))
            {
                return false;
            }
        }
        return true;
    }
