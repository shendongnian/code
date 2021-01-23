    public static string SurroundWithDoubleQuotes(this text)
    {
        return SurroundWith(text, "\"");
    }
    public static string SurroundWith(this text, string ends)
    {
        return ends + text + ends;
    }
