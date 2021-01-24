    string Tokenify(string path)
    {
        //first find all the environment variables that represent paths.
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
        //sort them by length so we always get the most specific one.
    	//if you are dealing with a large number of strings then orderedVars can be generated just once and cached.
        var orderedVars = validEnvVars.OrderByDescending(kv => kv.Value.Length);
    	foreach (var kv in orderedVars)
    	{
    		path = path.Replace(kv.Value, $"%{kv.Key}%");
    	}
    	return path;
    }
