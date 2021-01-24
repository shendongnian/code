    public static void ReplaceValues(string s, IEnumerable<string> newValues) 
    	{
    		if(dictionary.ContainsKey(s))
    		{
    			dictionary[s].Clear();
    			foreach(var val in newValues){
        			dictionary[s].Add(val);
    			}
    		}
    	}
