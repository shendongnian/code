    PropertyInfo[] props = typeof(model).GetProperties(BindingFlags.Public|BindingFlags.Instance);
    foreach (var item in props)
    {
       if (item.PropertyType.IsClass && item.PropertyType.Assembly.FullName == typeof(model).Assembly.FullName)
    	{
    	        PropertyInfo[] subClassProp = item.PropertyType.GetProperties(BindingFlags.Public|BindingFlags.Instance);
    	        foreach (var itemB in subClassProp)
    	        {
    	            // Your code 
    	        }
    	}
    }
