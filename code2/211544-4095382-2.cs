    Dictionary<string,List<string>> Merge(params Dictionary<string,string>[] dicts)
    {
    	var target = new Dictionary<string, List<string>>();
    	foreach(var dict in dicts)
    	{
    		foreach(var kvp in dict)
    		{
    			if(target.ContainsKey( kvp.Key ) )
    				target[kvp.Key].Add( kvp.Value );
    			else
    				target[kvp.Key] = new[] {kvp.Value} .ToList();
    		}
    	}
    	
    	return target;
    }
