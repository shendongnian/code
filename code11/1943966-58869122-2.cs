    public static class Guard
    {
    	/// <summary>
    	/// Throws an ArgumentNullException if any portion of a given property path is null.
    	/// </summary>
    	/// <typeparam name="T">The type to check.</typeparam>
    	/// <param name="instanceToCheck">The instance to check</param>
    	/// <param name="pathToCheck">The full path of the property to check. The path should include the name of the instance type.</param>
    	public static void ThrowIfNull<T>(T instanceToCheck, string pathToCheck)
    	{		
    		var propsToCheck = pathToCheck?.Split('.');
    		if (propsToCheck?.Any() != true)
    		{
    			throw new ArgumentNullException(nameof(pathToCheck));
    		}
    
    		if (typeof(T).Name != propsToCheck.First())
    		{
    			throw new ArgumentException($"The type of {nameof(instanceToCheck)} does not match the given {nameof(pathToCheck)}.");
    		}
    
    		if (instanceToCheck == null)
    		{
    			throw new ArgumentNullException($"{pathToCheck.First()}");
    		}
    
    		object currentObj = instanceToCheck;
    		for (var i = 1; i < propsToCheck.Length; i++)
    		{
    			var prop = currentObj.GetType().GetProperties().FirstOrDefault(x => x.Name == propsToCheck[i]);
    			if (prop == null)
    			{
    				throw new ArgumentException($"The path, '{string.Join(".", propsToCheck.Take(i + 1))}' could not be found.");
    			}
    			
    			currentObj = prop.GetValue(currentObj);
    			if (currentObj == null)
    			{
    				throw new ArgumentNullException($"{string.Join(".", propsToCheck.Take(i + 1))}");
    			}
    		}
    	}
    
    	/// <summary>
    	/// Throws an ArgumentNullException if any portion of a given property path is null.
    	/// </summary>
    	/// <typeparam name="T">The type to check.</typeparam>
    	/// <param name="instanceToCheck">The instance to check</param>
    	/// <param name="pathToCheck">The full path of the property to check.</param>
    	public static void ThrowIfNull<T, TProp>(T instanceToCheck, Expression<Func<T, TProp>> pathToCheck)
    	{
    		ThrowIfNull(instanceToCheck, (typeof(T).Name + pathToCheck.ToString().Substring(pathToCheck.ToString().IndexOf("."))));
    	}
    }
