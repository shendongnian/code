    Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        cfg.Host(new Uri("rabbitmq://localhost/test"), host =>
        {
            host.Username("username");
            host.Password("password");
        });
    }); 
