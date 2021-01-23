    ObjectFactory.Configure(c => c.Scan(x =>
                 {
                     x.TheCallingAssembly();
                     x.AddAllTypesOf<IMovementsManager>();
                 }));
