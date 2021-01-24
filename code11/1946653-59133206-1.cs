    public static T UpdateProperties<T>(this T source, T destination)
    {
    	Type type = source.GetType();   // Gets Source Object Type
    	PropertyInfo[] props = type.GetProperties();    // Gets Source object Properties
    
    	foreach (var prop in props)     // Iterate threw all properties of source object
    	{
    		var sourceValue = prop.GetValue(source);    // Get source object value by Property Name
    		var destinationValue = prop.GetValue(destination);      // Get destination object value by Property Name, to update source object
    
    		// Update source object property value only if derived object's property has value and source object doesn't
    		if (string.IsNullOrEmpty(sourceValue?.ToString()) && !string.IsNullOrEmpty(destinationValue?.ToString()))
    		{
    			prop.SetValue(source, destinationValue);    // Update source object's property with value of derived object
    		}
    	}
    	return source;
    }
