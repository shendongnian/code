    public static bool TryValidateObjectRecursive<T>(T obj, List<ValidationResult> results)
    {
    	bool result = TryValidateObject(obj, results);
    
    	var properties = obj.GetType().GetProperties().Where(prop => prop.CanRead).ToList();
    
    	foreach (var property in properties)
    	{
    		var value = obj.GetPropertyValue(property.Name);
    
    		if (value == null) continue;
    
    		var asEnumerable = value as IEnumerable;
    		if (asEnumerable != null)
    		{
    			foreach (var enumObj in asEnumerable)
    			{
    				result = TryValidateObjectRecursive(enumObj, results) && result;	
    			}
    		}
    		else
    		{
    			result = TryValidateObjectRecursive(value, results) && result;
    		}
    	}
    
    	return result;
    }
