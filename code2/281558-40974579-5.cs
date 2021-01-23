    ContainerBuilder builder = new ContainerBuilder();
    builder.RegisterType<TaskRepository>().As<ITaskRepository>();
    builder.RegisterType<TaskController>();
    builder.Register(c => new LogService(new DateTime(2000, 12, 12))).As<ILogger>();
    IContainer container = builder.Build();
    AutofacContractResolver contractResolver = new AutofacContractResolver(container);
    string json = @"{
          'Logger': {
            'Level':'Debug'
          }
    }";
    // ITaskRespository and ILogger constructor parameters are injected by Autofac 
    TaskController controller = JsonConvert.DeserializeObject<TaskController>(json, new JsonSerializerSettings
    {
        ContractResolver = contractResolver
    });
    Console.WriteLine(controller.Repository.GetType().Name);
