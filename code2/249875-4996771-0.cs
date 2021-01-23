    ConnectionFactory factory = new ConnectionFactory();
    factory.UserName = "user";
    factory.Password = "password";
    factory.VirtualHost = "/";
    factory.Protocol = Protocols.FromEnvironment();
    factory.HostName = "192.168.0.12";
    factory.Port = AmqpTcpEndpoint.UseDefaultPort;
    IConnection conn = factory.CreateConnection();
