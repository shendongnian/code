    public static Dictionary<string, string> EN_Dictionary = ...etc;
    public static Dictionary<string, string> FR_Dictionary  = ...etc;
    public static Dictionary<string, string> DE_Dictionary = ...etc;
    public static Dictionary<string, Dictionary<string, string>> myDictionaries 
        = new Dictionary<string, Dictionary<string, string>>()
        {
            { "EN", EN_Dictionary },
            { "FR", FR_Dictionary },
            { "DE", DE_Dictionary }
        };
