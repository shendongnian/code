    // Windsor latest
    container.Register(
        AllTypes.FromAssemblyNamed("MyApp.ServicesImpl")
        .Where(type => type.IsPublic)
        .WithService.DefaultInterface()
        );
