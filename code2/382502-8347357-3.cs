    using (var service = new Service())
    {
        if (Environment.UserInterActive)
        {
            Console.CancelKeyPress += (sender, e) => service.Dispose();
            service.Start();
            Thread.Sleep(Timeout.Infinite);
        }
        else
        {
            ServiceBase.Run(service);
        }
    }
