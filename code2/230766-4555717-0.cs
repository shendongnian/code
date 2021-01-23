    public static string encodeSTROnUrl(string thisEncode)
    {
        if (null == thisEncode)
            return string.Empty;
        return HttpUtility.UrlEncode(Encrypt(thisEncode));
    }
    public static string decodeSTROnUrl(string thisDecode)
    {
        return Decrypt(HttpUtility.UrlDecode(thisDecode));
    }
