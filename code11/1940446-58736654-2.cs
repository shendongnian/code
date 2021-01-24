    builder.RegisterType<Service>().As<IService>().InstancePerMatchingLifetimeScope("KEY");
    builder.RegisterType<DbContext>().InstancePerLifetimeScope();
    // ...
    using (ILifetimeScope scope = container.BeginLifetimeScope("KEY"))
    {
        scope.Resolve<IService>(); // Instance #1
        using (ILifetimeScope childScope = scope.BeginLifetimeScope())
        {
            childScope.Resolve<DbContext>();
            childScope.Resolve<IService>(); // shared instance (#1)
        }
    }
