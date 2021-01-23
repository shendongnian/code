    public static string EncodeServerName(string serverName)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(serverName));
    }
    public static string DecodeServerName(string encodedServername)
    {
        return Encoding.UTF8.GetString(Convert.FromBase64String(encodedServername));
    }
