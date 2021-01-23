    private static testInfoConfiguration myUrl; 
    public static string baseUrl = string.Empty;     
    [BeforeFeature("Test")] 
    public static void BeforeFeature_Test() 
    { 
        myUrl = new testInfoConfiguration(); 
        baseUrl = myUrl.setBaseUrl("Test");       
    } 
