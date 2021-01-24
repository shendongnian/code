    public static bool ContainsOnlyChars(string strValue, params char[] charValues)
    {
        if (string.IsNullOrEmpty(strValue))
            throw new ArgumentNullException("String cannot be null or empty.");
        return !strValue.Except(charValues).Any();
    }
