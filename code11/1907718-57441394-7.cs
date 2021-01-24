    try
    {
        ExceptionHelper<PlatformNotSupportedException>.ThrowIfDetected(Assembly.GetEntryAssembly().ReflectionOnlyLoadReferencedAssemblies());
    }
    catch(AggregateException e)
    {
        foreach (var inner in e.InnerExceptions)
            Console.WriteLine($"{inner.Message}\n");
    }
