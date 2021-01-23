    private static bool DictionaryEqual(
        Dictionary<string, List<string>> oldDict, 
        Dictionary<string, List<string>> newDict)
    {
        // Simple check, are the counts the same?
        if (!oldDict.Count.Equals(newDict.Count)) return false;
    
        // Verify the keys
        if (!oldDict.Keys.SequenceEqual(newDict.Keys)) return false;
    
        // Verify the values for each key
        foreach (string key in oldDict.Keys)
            if (!oldDict[key].SequenceEqual(newDict[key]))
                return false;
    
        return true;
    }
