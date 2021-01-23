    public static DateTime GetDateTime(long jsSeconds)
    {
        DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return unixEpoch.AddSeconds(jsSeconds);
    }
