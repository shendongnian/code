    IEnumerable<string> GetFoldersRecursive(string directory)
    {
    	var result = new List<string>();
    	var stack = new Stack<string>();
    	stack.Push(directory);
    
    	while (stack.Count > 0)
    	{
    		var dir = stack.Pop();
    
    		try
    		{
    			result.AddRange(Directory.GetDirectories(dir, "*.*"));
    			foreach (string dn in Directory.GetDirectories(dir))
    			{
    				stack.Push(dn);
    			}
    		}
    		catch
    		{
    		}
    	}
    
    	return result;
    }
