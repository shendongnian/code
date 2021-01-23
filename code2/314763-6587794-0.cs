    public static string Platform
    {
        get 
        {
            if (IntPtr.Size == 8)
                return "x64";
            else
                return "x86";
        }
    }
