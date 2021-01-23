    public static string SafeSubstring(this string text, int maxLength)
    {
        // TODO: Argument validation
        // If we're asked for more than we've got, we can just return the
        // original reference
        return text.Length > maxLength ? text.Substring(0, maxLength) : text;
    }
