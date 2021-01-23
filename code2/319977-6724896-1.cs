    public static string Truncate(this string value, int maxChars)
    {
         if (string.IsNullOrEmpty(value)) return value; 
         return value.Length <= maxChars ? value : value.Substring(0, maxChars) + " ..";
    }
