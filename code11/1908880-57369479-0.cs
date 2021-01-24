    private Dictionary<string[], ICommand> commandsWithAttributes = new Dictionary<string[], ICommand>();
    private ICommand FindByKey(string key)
    	{
    		foreach (var p in commandsWithAttributes)
    		{
    			if (p.Key.Any(k => k.Equals(key)))
    			{
    				return p.Value;
    			}
    		}
    
    		return null;
    	}
