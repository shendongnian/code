        // reference dictionary - pass LangID string to reference appropriate dictionary
        public static Dictionary<string, Dictionary<string, string>> myDictionaries = new Dictionary<string, Dictionary<string, string>>()
        {
            { "EN", EN_Dictionary },
            { "FR", FR_Dictionary },
            { "DE", DE_Dictionary }
        };
        public static Dictionary<string, string> EN_Dictionary = new Dictionary<string, string>()
        {
            { "str1", "Some text in EN" },
            { "str2", "Some text in EN" },
            { "str3", "Some text in EN" }
        };
        public static Dictionary<string, string> FR_Dictionary = new Dictionary<string, string>()
        // FR language dictionary
        {
            { "str1", "Some text in FR" },
            { "str2", "Some text in FR" },
            { "str3", "Some text in FR" }
};
        public static Dictionary<string, string> DE_Dictionary = new Dictionary<string, string>()
        // DE language dictionary
        {
            { "str1", "Some text in DE" },
            { "str2", "Some text in DE" },
            { "str3", "Some text in DE" }
        };
