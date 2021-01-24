    public static Stream StringAsStream(string value)
    {
        return StringAsStream(value, System.Text.Encoding.UTF8);
    }
    public static Stream StringAsStream(string value, System.Text.Encoding encoding)
    {
        var bytes = encoding.GetBytes(value);
        return new MemoryStream(bytes);
    }
