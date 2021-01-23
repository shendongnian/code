    public static List<T> GetFilePlugins<T>(string filename)
    {
    	List<T> ret = new List<T>();
    	if (File.Exists(filename))
    	{
    		Type typeT = typeof(T);
    		Assembly ass = Assembly.LoadFrom(filename);
    		foreach (Type type in ass.GetTypes())
    		{
    			if (!type.IsClass || type.IsNotPublic) continue;
    			if (typeT.IsAssignableFrom(type))
    			{
    				T plugin = (T)Activator.CreateInstance(type);
    				ret.Add(plugin);
    			}
    		}
    	}
    	return ret;
    }
    public static List<T> GetDirectoryPlugins<T>(string dirname)
    {
    	List<T> ret = new List<T>();
    	string[] dlls = Directory.GetFiles(dirname, "*.dll");
    	foreach (string dll in dlls)
    	{
    		List<T> dll_plugins = GetFilePlugins<T>(Path.GetFullPath(dll));
    		ret.AddRange(dll_plugins);
    	}
    	return ret;
    }
