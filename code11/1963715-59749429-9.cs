    public static class MyExtension
    {
    	// input is the input string to split
    	// limit is the number of desired substrings to output
    	public static IEnumerable<string> ReverseSplit(this string input, int limit = 6)
    	{
    		var temp = new StringBuilder();
    
    		for (int i = input.Length - 1; i >= 0; i--)
    		{
    			if (input[i] == '_' && limit > 1)
    			{
    				yield return temp.ToString();
    				temp.Clear();
    				limit--;
    			}
    			else
    			{
    				temp.Insert(0, input[i]);
    			}
    		}
    		// return the last element
    		if (temp.Length > 0)
    			yield return temp.ToString();
    	}
    }
