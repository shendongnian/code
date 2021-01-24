    var types = Assembly
        .GetEntryAssembly()
        .GetReferencedAssemblies()
        .Select(s => s.GetType())
        .Where(p => typeof(ICommandHandler<>).IsAssignableFrom(p) || typeof(IQueryHandler<>).IsAssignableFrom(p));
