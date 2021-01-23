    private static String EncodeToKey(String originalKey)
    {
        var keyBytes = System.Text.Encoding.UTF8.GetBytes(originalKey);
        var base64 = System.Convert.ToBase64String(keyBytes);
        return base64.Replace('/','_');
    }
