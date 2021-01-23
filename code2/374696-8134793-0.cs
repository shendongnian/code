    private static string GetString(byte[] bytes)
    {
        return Encoding.Unicode.GetString(bytes);
    }
    
    private static byte[] GetBytes(string value)
    {
        return Encoding.Unicode.GetBytes(value);
    }
