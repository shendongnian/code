    public void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ISagaRepository<Request>, InMemorySagaRepository<Request>>();
        services.AddMassTransit(
            provider => 
                Bus.Factory.CreateUsingInMemory(cfg =>
                {
                    cfg.UseInMemoryOutbox();
                    cfg.ConfigureEndpoints(provider);
                },
            x => x.AddSagaStateMachine<RequestStateMachine, Request>()
        );
    }
