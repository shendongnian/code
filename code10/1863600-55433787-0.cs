    var assembly = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load);
    	var definedTypes = assembly.SelectMany(a => a.DefinedTypes);
    	var types = definedTypes.ToList().Select(dt => dt.AsType());
    	
    	types.Dump();
    		
    	var toRet = types.Any(t => t.IsClass && t.IsInstanceOfType(typeof(LibraryClass1)));
