    // Windsor latest
    container.Register(
        AllTypes.FromAssemblyNamed("MyApp.ServicesImpl")
        .Where(type => type.IsPublic) // Filtering on public isn't really necessary (see comments) but you could put additional filtering here
        .WithService.DefaultInterface()
        );
