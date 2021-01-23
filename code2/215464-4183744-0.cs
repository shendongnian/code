    AppDomain myDomain = AppDomain.CurrentDomain;
    Assembly[] loadedAssemblies = MyDomain.GetAssemblies();
    foreach(Assembly assembly in loadedAssemblies)
    {
    	Type[] types = assembly.GetTypes();
    	foreach (Type type in types)
    	{
    		if (type.GetInterface(interface name) != null)
    			Console.WriteLine(type.Name);
    	}
    }
