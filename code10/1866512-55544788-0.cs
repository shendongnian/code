    var types = Assembly.GetExecutingAssembly()
        .GetExportedTypes()
        .Where
        (
            r => r.GetInterfaces().Any
            (
                i => i.IsGenericType 
                  && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)
            )
        );
