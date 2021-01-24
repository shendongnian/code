    Dictionary<string,string> languageConfigLookup = 
        new Dictionary<string,string>() {
            {"french",JSonConfigFile.FrenchPropName},
            {"english",JSonConfigFile.EnglishPropName}
        };
    if (languageConfigLookup.TryGetValue(GetCurrentLanguage().ToLower(), out string propertyName))
    {
       Value2Get = GetSolidworksProp(propertyName);
    }
    else 
    { 
       throw new Exception("Not-Handled");
    }
