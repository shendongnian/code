    var resolver = new DefaultAssemblyResolver();
    resolver.AddSearchDirectory("path/to/my/assemblies");
    
    var parameters = new ReaderParameters
    {
    	AssemblyResolver = resolver,
    };
    
    var assembly = AssemblyDefinition.ReadAssembly(pathToAssembly, parameters);
