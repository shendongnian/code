    private static string[] mobileDevices = new string[] {"iphone","ppc"
                                                          "windows ce","blackberry",
                                                          "opera mini","mobile","palm"
                                                          "portable","opera mobi" };
    public static bool IsMobileDevice(string userAgent)  
    {  
        // TODO: null check
        userAgent = userAgent.ToLower();  
        return mobileDevices.Contains(userAgent);
    }
