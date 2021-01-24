    public static object ParseEnum(Type enumType, NamingStrategy? namingStrategy, string value, bool disallowNumber)
    {
    // SNIP
        if (firstNonWhitespaceIndex == -1)
        {
            throw new ArgumentException("Must specify valid information for parsing in the string.");
        }
