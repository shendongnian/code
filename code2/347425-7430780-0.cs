            ObjectFactory.Initialize(x =>
            {
                // here I want to use the registered concrete implmentaiton of IDocumentStore
                x.Scan(scan =>
                           {
                               scan.TheCallingAssembly();
                               scan.AssembliesFromApplicationBaseDirectory();
                               scan.LookForRegistries();
                           });
                x.For<IDocumentStore>().Use(c =>
                    c.GetInstance<IDocumentStoreInitializer>().
                        InitializeDocumentStore()).OnCreation<IDocumentStore>(z => z.Initialize());
            });
