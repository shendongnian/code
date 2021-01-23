    private static String DecodeFromKey(String encodedKey)
    {
        var base64 = encodedKey.Replace('_', '/');
        byte[] bytes = System.Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(bytes);
    }
