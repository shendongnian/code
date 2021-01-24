    public static class Guard
    {
    
    	public static void ThrowIfNull<T>(T instanceToCheck, string pathToCheck)
    	{
    		var propsToCheck = pathToCheck?.Split('.');
    		object currentObj = instanceToCheck;
    
    		if (propsToCheck?.Any() != true)
    		{
    			throw new ArgumentException();
    		}
    
    		if (typeof(T).Name != propsToCheck.First())
    		{
    			throw new ArgumentException("Object type does not match given path.");
    		}
    
    		if (instanceToCheck == null)
    		{
    			throw new ArgumentNullException($"{typeof(T).Name}");
    		}
    
    
    		for (var i = 1; i < propsToCheck.Length; i++)
    		{
    			var properties = currentObj.GetType().GetProperties();
    			var prop = properties.FirstOrDefault(x => x.Name == propsToCheck[i]);
    
    			if (prop == null)
    			{
    				throw new ArgumentException($"The path, '{string.Join(".", propsToCheck.Take(i + 1))}' could not be found.");
    			}
    			currentObj = prop.GetValue(currentObj);
    			if (currentObj == null)
    			{
    				throw new ArgumentNullException("", $"{string.Join(".", propsToCheck.Take(i + 1))}");
    			}
    		}
    	}
    
    	public static void ThrowIfNull<T,TProp>(T instanceToCheck, Expression<Func<T, TProp>> pathToCheck)
    	{		
    		ThrowIfNull(instanceToCheck, (typeof(T).Name + pathToCheck.ToString().Substring(pathToCheck.ToString().IndexOf("."))));
    	}
    }
