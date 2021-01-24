    builder.Register(c => c.Resolve<IClientContextProvider>().GetClientContext())
           .As<IClientContext>()
           .InstancePerLifetime(); 
    builder.Register(c => c.Resolve<IDbContextFactory>().CreateDbContext())
           .As<IDbContext>()
           .InstancePerLifetime(); 
