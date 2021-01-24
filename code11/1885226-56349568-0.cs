    public Dictionary<string, string> GetSettings()
    {
        var settingsValues = new Dictionary<string, string>();
        foreach (var valueDict in Values)
        {
            foreach (var setting in valueDict)
            {
                settingsValues.Add(setting.Key, setting.Value);
            }
        }
        return settingsValues;
    }
