    // Don't just call it Reverse as otherwise it conflicts with the LINQ version.
    public static string ReverseText(this string text)
    {
        char[] chars = text.ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
