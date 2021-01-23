        string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
        //Check the directory exists
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        //Create an assembly catalog of the assemblies with exports
        var catalog = new AggregateCatalog(
            new AssemblyCatalog(Assembly.GetExecutingAssembly()),
            new AssemblyCatalog(Assembly.Load("My.Other.Assembly")),
            new DirectoryCatalog(path, "*.dll"));
        //Create a composition container
        _container = new CompositionContainer(catalog);  
