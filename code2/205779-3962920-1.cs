     protected override IModuleCatalog GetModuleCatalog()
        {
            var catalog = new ModuleCatalog();
            catalog.AddModule(typeof(TMBLCoreModule), InitializationMode.WhenAvailable);
            catalog.AddModule(typeof(NewsModule), InitializationMode.WhenAvailable);
            catalog.AddModule(typeof(UserModule), InitializationMode.WhenAvailable);
            return catalog;
        }
