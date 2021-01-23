    public static string Get()
    {
        lock(syncRoot)
        {
            if (string.IsNullOrEmpty(TOKEN) || !TokenIsValid())
                TOKEN = CreateNewToken();
            return TOKEN;
        }
    }
