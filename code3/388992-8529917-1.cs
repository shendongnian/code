    public string ToProperCase(string str)
    {
        if (string.IsNullOrEmpty(str))
             return str;
        return str[0].ToUpper() + str.Substring(1).ToLower();
    }
    // or an extension method
    public static string ToProperCase(this string str)
    {
        if (string.IsNullOrEmpty(str))
             return str;
        return str[0].ToUpper() + str.Substring(1).ToLower();
    }
