    string Tokenify(string path)
    {
    	var validEnvVars = new List<KeyValuePair<string, string>>();
    	foreach (var v in Environment.GetEnvironmentVariables())
    	{		
    		var e = (DictionaryEntry)v;
    		string envPath = e.Value.ToString();
    		if (System.IO.Directory.Exists(envPath))
    		{
    			validEnvVars.Add(new KeyValuePair<string, string>(e.Key.ToString(), envPath));
    		}
    	}
    	var orderedVars = validEnvVars
    		.OrderByDescending(kv => kv.Value.Length)
    		.ToList();
    	
    	foreach (var kv in orderedVars)
    	{
    		path = path.Replace(kv.Value, $"%{kv.Key}%");
    	}
    	return path;
    }
