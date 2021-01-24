    using (var manager = new RabbitMQManager())
    {
        manager.MessageReceived += (sender, msg) => Console.WriteLine(msg);
        manager.Connect();
        Console.Read();
    }
