    public static string Repeat(this string text, int count)
    {
        if (!String.IsNullOrEmpty(text))
        {
            return String.Concat(Enumerable.Repeat(text, count));
        }
        return "";
    }
