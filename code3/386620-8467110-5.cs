    IUnityContainer container;
    // ...
    container.RegisterType<IProcess, ProcessImplementation1>();
    container.RegisterType<IProcess, ProcessImplementation2>();
    container.RegisterType<IProcess, ProcessImplementation3>();
    // ...
    container.TryAllImplementations(
        (IProcess svc) => svc.ProcessItem(workType),
        ex => Console.WriteLine(
            "  Failed: {0} - {1}.",
            ex.GetType(), 
            ex.Message));
