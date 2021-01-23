    /// <summary>
    /// Creates the composition container.
    /// </summary>
    /// <returns></returns>
    protected virtual CompositionContainer CreateCompositionContainer()
    {
        var catalog = new AggregateCatalog();
        catalog.Catalogs.Add(new DirectoryCatalog(MapPath("~/bin")));
        var config = CompositionConfigurationSection.GetInstance();
        if (config != null && config.Catalogs != null) {
            config.Catalogs
                .Cast<CatalogConfigurationElement>()
                .ForEach(c =>
                {
                    if (!string.IsNullOrEmpty(c.Path)) {
                        string path = c.Path;
                        if (path.StartsWith("~"))
                            path = MapPath(path);
                        foreach (var directoryCatalog in GetDirectoryCatalogs(path)) {
                            // Register our path for probing.
                            RegisterPath(directoryCatalog.FullPath);
                            // Add the catalog.
                            catalog.Catalogs.Add(directoryCatalog);
                        }
                    }
                });
        }
        var provider = new DynamicInstantiationExportProvider();
        var container = new CompositionContainer(catalog, provider);
        provider.SourceProvider = container;
        return container;
    }
