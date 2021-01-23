    public static string SurroundWithDoubleQuotes(this string text)
    {
        return SurroundWith(text, "\"");
    }
    public static string SurroundWith(this string text, string ends)
    {
        return ends + text + ends;
    }
