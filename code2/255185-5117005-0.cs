    /// <summary>
    /// Gets a value indicating whether we are running under Linux or a Unix variant. Returns <c>true</c> 
    /// if Linux/Unix; otherwise, <c>false</c>.
    /// </summary>
    public static bool IsLinux
    {
        get
        {
            int platform = (int) Environment.OSVersion.Platform;
            return platform == 4 || platform == 128;
        }
    }
