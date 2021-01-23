    string[] files = Directory.GetFiles(ClientPluginStore, "*.dll", SearchOption.TopDirectoryOnly);
        
    AggregateCatalog aggCat = new AggregateCatalog();
        
    aggCat.Catalogs.Add(catalog);
        
    foreach ( string file in files )
    {
        Assembly ass = Assembly.LoadFrom(file);
        
        AssemblyCatalog assCat = new AssemblyCatalog(ass);
    
        aggCat.Catalogs.Add(assCat);
    }
        
    _container = new CompositionContainer(aggCat);
