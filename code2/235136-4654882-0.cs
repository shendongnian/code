    public static string Lookup(Type type)
    {
    	string result;
    
    	lock (_syncRoot) { }
    	_lookup.TryGetValue(type, out result);		
    
    	return result;
    }
