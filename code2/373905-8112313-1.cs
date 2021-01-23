    public static string Truncate(this string value, int maxChars)
    {
        return value == null ? null
            : value.Length <= maxChars ? value 
            : value.Substring(0, maxChars) + " ..";
    }
