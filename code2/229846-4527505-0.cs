      Configuration cfg = Fluently.Configure()
            .Database(SQLiteConfiguration.Standard.InMemory())
            .Mappings(m => m.HbmMappings.AddFromAssembly(_mappingsAssembly))
            .BuildConfiguration();
        var session = cfg.BuildSessionFactory().OpenSession();
        new SchemaExport(cfg).Execute(false, true, false, session.Connection, null);
