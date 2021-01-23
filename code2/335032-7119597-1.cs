    public static string Base64AndUtf8Encode(string text)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(text);
        return Convert.ToBase64String(bytes);
    }
    public static string Base64AndUtf8Decode(string base64)
    {
        bytes[] bytes = Convert.FromBase64String(base64);
        return Encoding.UTF8.GetString(bytes);
    }
