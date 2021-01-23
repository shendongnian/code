    string DependenciesPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Dependencies");
    string[] Dependencies   = Directory.GetFiles(DependenciesPath, DLL_PATTERN);
    Dictionary<Type, Type> pluginMappings = new Dictionary<Type, Type>();
    //Load Dependency Assemblies
    foreach (string fileName in Dependencies)
    {
    	string assemblyName = Path.GetFileNameWithoutExtension(fileName);
    	if (assemblyName != null)
    	{
    		Assembly pluginAssembly = Assembly.Load(assemblyName);
    
    		foreach (Type pluginType in pluginAssembly.GetTypes())
    		{
    			if (pluginType.IsPublic) //Only look at public types
    			{
    				if (!pluginType.IsAbstract)  //Only look at non-abstract types
    				{
    					//Gets a type object of the interface we need the plugins to match
    					Type[] typeInterfaces = pluginType.GetInterfaces();
    					foreach (Type typeInterface in typeInterfaces)
    					{
    						if (pluginMappings.ContainsKey(typeInterface))
    						{
    							throw new DuplicateTypeMappingException(typeInterface.Name, typeInterface, pluginMappings[typeInterface], pluginType);
    						}
    						pluginMappings.Add(typeInterface, pluginType);
    					}
    				}
    			}
    		}
    	}
    }
    
    //Web API resolve dependencies with Unity
    IUnityContainer container = new UnityContainer();
    foreach (var mapping in pluginMappings)
    {
    	container.RegisterType(mapping.Key, mapping.Value);
    }
