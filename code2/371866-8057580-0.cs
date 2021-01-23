    private static testInfoConfiguration myUrl; 
    public string baseUrl = "";     
    [BeforeFeature("Test")] 
    public static string BeforeFeature_Test() 
    { 
        myUrl = new testInfoConfiguration(); 
        string baseUrl = myUrl.setBaseUrl("Test"); 
        return baseUrl; 
    } 
