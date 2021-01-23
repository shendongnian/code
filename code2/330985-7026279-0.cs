    public string DecodeBase64(string s)
    {
        byte[] buf = Convert.FromBase64String(s);
        return System.Text.Encoding.UTF8.GetString(buf);
    }
