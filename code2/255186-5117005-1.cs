    public static bool IsLinux
    {
        get
        {
            int platform = (int) Environment.OSVersion.Platform;
            return (p == 4) || (p == 6) || (p == 128)
        }
    }
