    private static string[] SplitKeepDelimiters(string toSplit, char[] delimiters, StringSplitOptions splitOptions = StringSplitOptions.None)
    {
    	var tokens = new List<string>();
    	int idx = 0;
    	for (int i = 0; i < toSplit.Length; ++i)
    	{
    		if (delimiters.Contains(toSplit[i]))
    		{
    			tokens.Add(toSplit.Substring(idx, i - idx));  // token found
    			tokens.Add(toSplit[i].ToString());            // delimiter
    			idx = i + 1;                                  // start idx for the next token
    		}
    	}
    
    	// last token
    	tokens.Add(toSplit.Substring(idx));
    
    	if (splitOptions == StringSplitOptions.RemoveEmptyEntries)
    	{
    		tokens = tokens.Where(token => token.Length > 0).ToList();
    	}
    
    	return tokens.ToArray();
    }
