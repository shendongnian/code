    public static string UpperFirst(this string source)
    {
        return source.ToLower().Remove(0, 1)
                .Insert(0, source.Substring(0, 1).ToUpper());
    }
