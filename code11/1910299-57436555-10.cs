    string Tokenify(string path)
    {
	    foreach (DictionaryEntry e in Environment.GetEnvironmentVariables())
    	{
	    	int index = path.IndexOf(e.Value.ToString());
            if (index > -1)
            {
                //we need to make sure we're not already inside a tokenized part.
	    	    int numDelimiters = path.Take(index).Count(c => c == '%');
    	    	if (numDelimiters % 2 == 0)
    	    	{
    	    		path = path.Replace(e.Value.ToString(), $"%{e.Key.ToString()}%");
    	    	}
            }
    	}
	    return path;
    }
