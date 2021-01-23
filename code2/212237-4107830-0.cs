    private bool Load(IEnumerable<string> addinDirectories)
    {
        var catalog = new AggregateCatalog();
        catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetEntryAssembly()));
        foreach (string dir in addinDirectories)
        {
            DirectoryCatalog dc = new DirectoryCatalog(dir);
            catalog.Catalogs.Add(dc);
        }
        this.container = new CompositionContainer(catalog);
        CompositionBatch batch = new CompositionBatch();
        batch.AddPart(this);
        batch.AddExportedValue(container);
        this.container.Compose(batch);
        return this.success;
    }
