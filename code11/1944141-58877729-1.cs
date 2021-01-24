    builder.Register(c => {
        IApplicationSettings appSettings = c.Resolve<IApplicationSettings>();
        IQueueClient queueClient = new QueueClient(appSettings.GetServiceBusConnectionString(), appSettings.GetQueueName());
        return queueClient;
    })
    .As<IQueueClient>()
    .InstancePerLifetimeScope();
