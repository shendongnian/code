    public static string Truncate(this string value, int maxChars)
    {
        if (value == null)
        {
            return null;
        }
        return value.Length <= maxChars ?
               value : value.Substring(0, maxChars) + " ..";
    }
