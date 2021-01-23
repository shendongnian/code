    List<Type> attributes = new List<Type>();
    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
    {
    	foreach (Type type in assembly.GetTypes())
    	{
    		if (typeof(Attribute).IsAssignableFrom(type))
    		{
    			attributes.Add(type);
    		}
    	}					
    }
