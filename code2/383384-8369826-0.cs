    public static string GetUserPath()
    {
        string path = Settings.Default.UserPath;
        if (string.IsNullOrEmpty(path))
            path = Application.UserAppDataPath;
        return path;
    }
