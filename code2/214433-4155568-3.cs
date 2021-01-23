    public static StringBuilder Translate(this StringBuilder builder,
        string pattern, string replacement)
    {
        int length = Math.Min(pattern.Length, replacement.Length);
        for (int i = 0; i < length; ++i) {
            builder.Replace(pattern[i], replacement[i]);
        }
        return builder;
    }
