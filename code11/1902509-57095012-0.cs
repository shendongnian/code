    var bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        cfg.Host(new Uri("rabbitmq://production/vhost"), h =>
        {
            h.Username(_username);
            h.Password(_password);
            h.UseCluster(c =>
            {
                c.Node("server1");
                c.Node("server2");
                c.Node("server3");
            });
        });
    });
    bus.Start();
    var endpoint = bus.GetSendEndpoint(new Uri("rabbitmq://production/vhost/my_queue"));
