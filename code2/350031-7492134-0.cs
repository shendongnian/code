    public static TValue? GetValueOrNull<TValue?>(
    IDictionary<string, Dictionary<string, TValue>> cacheDictionary,
    object cacheMutex,
    string categoryName,
    string settingName)
    {
    TValue? value = null;
    lock (cacheMutex)
    {
        if (cacheDictionary.ContainsKey(categoryName))
        {
            if (cacheDictionary[categoryName].ContainsKey(settingName))
            {
                value = cacheDictionary[categoryName][settingName];
            }
        }
    }
    return value;
    }
