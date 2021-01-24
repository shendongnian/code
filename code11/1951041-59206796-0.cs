HttpContext.Current.Items.Add("EnableDebugMode", true);
...
    public static bool GetEnableDebugMode()
    {
        return (bool)HttpContext.Current.Items["EnableDebugMode"];
    }
