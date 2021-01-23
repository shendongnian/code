    public static bool GetValueOrNull<TValue>(
    	IDictionary<string, Dictionary<string, TValue>> cacheDictionary,
    	object cacheMutex,
    	string categoryName,
    	string settingName,
    	out TValue value)
    {
    	lock (cacheMutex) {
    		Dictionary<string, TValue> category;
    		if (cacheDictionary.TryGetValue(categoryName, out category)) {
    			if (category.TryGetValue(settingName, out value))
    				return true; // setting was found
    		}
    	}
    
    	value = default(TValue);
    	return false; // setting was not found
    }
