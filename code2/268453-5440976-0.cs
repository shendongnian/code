    container.RegisterType<ITool, ToolA>("ToolA");
    container.RegisterType<ITool, ToolB>("ToolB");
    container.RegisterType<ITool, ToolC>("ToolC");
    container.RegisterType<IWorker, Worker>("WorkerA", 
        new InjectionConstructor(new ResolvedParameter<ITool>("ToolA")));
    container.RegisterType<IWorker, Worker>("WorkerB", 
        new InjectionConstructor(new ResolvedParameter<ITool>("ToolB")));
    container.RegisterType<IWorker, Worker>("WorkerC", 
        new InjectionConstructor(new ResolvedParameter<ITool>("ToolC")));
