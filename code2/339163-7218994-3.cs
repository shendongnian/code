    BasedOnDescriptor processes = AllTypes.FromAssembly(assemblyWithProcesses)
        .BasedOn(typeof (IProcess<,>))
        .WithService.AllInterfaces()
        .Configure(x => x.LifeStyle.Transient);
    container.Register(processes)
