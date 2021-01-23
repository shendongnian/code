    private static bool DictionaryEqual_NoSort(
    	Dictionary<string, List<string>> oldDict,
    	Dictionary<string, List<string>> newDict)
    {
    	// Simple check, are the counts the same?
    	if (!oldDict.Count.Equals(newDict.Count)) return false;
    
    	// iterate through all the keys in oldDict and
    	// verify whether the key exists in the newDict
    	foreach(string key in oldDict.Keys)
    	{
    		if (newDict.Keys.Contains(key))
    		{
    			// iterate through each value for the current key in oldDict and 
    			// verify whether or not it exists for the current key in the newDict
    			foreach(string value in oldDict[key])
    				if (!newDict[key].Contains(value)) return false;
    		}
    		else { return false; }
    	}
    
    	return true;
    }
