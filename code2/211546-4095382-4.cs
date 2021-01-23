    Dictionary<string,List<string>> Merge(params Dictionary<string,string>[] dicts)
    {
    	var target = new Dictionary<string, List<string>>();
    	var allKeys = dicts.SelectMany(d => d.Keys).Distinct();
    	
    	foreach(var key in allKeys)
    	{
    		foreach(var dict in dicts)
    		{
    			if(target.ContainsKey( key ) )
    			{
    				target[key].Add( dict.ContainsKey(key) ? dict[key] : "" );
    			}
    			else
    			{
    				target[key] = new[] {dict.ContainsKey(key) ? dict[key] : ""} .ToList();
    			}
    		}
    	}
    	
    	return target;
    }
