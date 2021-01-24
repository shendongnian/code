    string Tokenify(string path)
    {
        //first find all the environment variables that represent paths.
    	var validEnvVars = new List<KeyValuePair<string, string>>();
    	foreach (DictionaryEntry e in Environment.GetEnvironmentVariables())
    	{		
    		string envPath = e.Value.ToString();
    		if (System.IO.Directory.Exists(envPath))
    		{
                //this would be the place to add any other filters.
    			validEnvVars.Add(new KeyValuePair<string, string>(e.Key.ToString(), envPath));
    		}
    	}
        //sort them by length so we always get the most specific one.
    	//if you are dealing with a large number of strings then orderedVars can be generated just once and cached.
        var orderedVars = validEnvVars.OrderByDescending(kv => kv.Value.Length);
    	foreach (var kv in orderedVars)
    	{
            //using regex just for case insensitivity. Otherwise just use string.Replace.
    		path = Regex.Replace(path, Regex.Escape(kv.Value), $"%{kv.Key}%", RegexOptions.IgnoreCase);
    	}
    	return path;
    }
