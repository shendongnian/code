    public static bool CanBeRoundTripped(Encoding encoding, string text)
    {
        byte[] bytes = encoding.GetBytes(text);
        string decoded = encoding.GetString(bytes);
        return text == decoded;
    }
