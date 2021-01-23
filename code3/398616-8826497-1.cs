    static private A _a1;
    public static A LoadPackage(string filePath)
    {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(filePath));
            var _container = new CompositionContainer(catalog);
            _a1 = _container.GetExportedValue<A>();
    }
