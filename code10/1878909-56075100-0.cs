var rabbitMqHost = busFactoryConfig.Host(new Uri("rabbitmq://rabbit2/"), hostConfig =>
{
    hostConfig.Username("username");
    hostConfig.Password("password");
    hostConfig.UseCluster(c =>
    {
        c.Node("rabbit");
        c.Node("rabbit1");
        c.Node("rabbit2");
    });
});
And I added following to the hosts file :
127.0.0.1 rabbit2
