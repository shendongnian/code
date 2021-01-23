    ObjectFactory.Initialize(c =>
        {
            c.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.ExcludeType<IMeasureRepository>();
                });
        });
