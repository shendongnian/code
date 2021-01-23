    if (line.ContainsCaseInsensitive(value)
    {
        // ..
    }
    public static bool ContainsCaseInsensitive(this string source, string find)
    {
        return source.IndexOf(find, StringComparison.CurrentCultureIgnoreCase) != -1;
    }
