    container.RegisterTypes(
        AllClasses.FromLoadedAssemblies().
            Where(type => typeof(IMyClass).IsAssignableFrom(type)),
        WithMappings.FromAllInterfaces,
        WithName.TypeName,
        WithLifetime.PerResolve);
    container.RegisterType<IEnumerable<IMyClass>, IMyClass[]>();
