    services.Scan(scan => scan
        .FromAssemblyOf<Startup>()
            .AddClasses(c => c.InNamespaces("MyApp.Services"))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
    );
