    public static string DecodeString(string s)
    {
        byte[] b = Convert.FromBase64String(s);
        return System.Text.Encoding.Default.GetString(b);
    }
