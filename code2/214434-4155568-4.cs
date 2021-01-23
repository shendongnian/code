    public static StringBuilder Translate(this StringBuilder builder,
        string inChars, string outChars)
    {
        int length = Math.Min(inChars.Length, outChars.Length);
        for (int i = 0; i < length; ++i) {
            builder.Replace(inChars[i], outChars[i]);
        }
        return builder;
    }
