    private void RegisterContext(ContainerBuilder builder) {
        var options = new DbContextOptionsBuilder<MyContext>();
        options.UseSqlServer(_connectionString);
        builder.RegisterInstance(options.Options).As<DbContextOption<MyContext>>();
    
        builder.RegisterType<CurrentUserService>()
            .AsImplementedInterfaces().InstancePerLifetimeScope();
    
        builder.RegisterType<MyContext>().AsSelf().InstancePerLifetimeScope();
    }
