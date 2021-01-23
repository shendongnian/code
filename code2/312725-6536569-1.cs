    public static T DontReplaceIfNullOrEmpty<T>(this T c, T d)
    {
        return c != null ? c : d;
    }
    object e = c.DontReplaceIfNull<string>(d);
