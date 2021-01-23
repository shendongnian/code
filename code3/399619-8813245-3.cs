    // Note this function is almost unnecessary and might be better
    // implemented in AddIfRequired if validation is this trivial.
    public static bool IsRequired(string text)
    {
        return string.IsNullOrWhiteSpace(text);
    }
