    public static string UrlEncode(string str)
    {
        if (str == null)
        {
            return null;
        }
        return UrlEncode(str, Encoding.UTF8);
    }
