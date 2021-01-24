    public static void ReplaceValues(string s, IEnumerable<string> newValues) 
    {
    	if(dictionary.ContainsKey(s))
        	dictionary[s]  =  new HashSet<string>(newValues);
    }
