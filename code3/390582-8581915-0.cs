    static Type GetIRepositoryType(Type type)
    {
        return type.GetInterfaces()
            .Where(i => i.IsGenericType
                && i.GetGenericTypeDefinition() == typeof(IRepository<>))
            .Single();
    }
    builder.RegisterAssemblyTypes(this.GetType().Assembly)
        .Where(t => t.IsClosedTypeOf(typeof(DbContextRepository<>)))
        .As(t => new Autofac.Core.KeyedService("repo2", GetIRepositoryType(t)))
        .PropertiesAutowired();
