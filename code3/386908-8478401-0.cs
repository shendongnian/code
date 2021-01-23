    List<CustomObject> Objects = new List<CustomObject>();
    
    Assembly asm = Assembly.LoadFrom(assemblyPath);
    Type[] types = asm.GetTypes();
    
    foreach (var t in types)
    {
    	if (t.IsClass && t.IsSubclassOf(typeof(CustomObject)))
    	{
    		var instance = (CustomObject) Activator.CreateObject(t);
    		
    		if (!Objects.Contains(instance))
    			Objects.Add(instance);
    	}
    }
