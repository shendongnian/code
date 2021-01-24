        services.AddMassTransit(x =>
        {
            x.AddConsumer<Consumers.UpdateCustomerConsumer>(); //added this line
            x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri("rabbitmq://localhost:5672/"), h => { });
                cfg.ReceiveEndpoint("test", ep =>
                {
                    ep.ConfigureConsumer<Consumers.UpdateCustomerConsumer>(provider); //changed
                });
                //if you use cfg.ReceiveEndpoint this one is not needed
                //you can remove cfg.ReceiveEndpoint and use below instead
                //cfg.ConfigureEndpoints(provider); 
            }));
        });
        services.AddSingleton<IJimTest, JimTest>();
  [1]: https://masstransit-project.com/usage/containers/msdi.html
