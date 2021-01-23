    using (var service = new Service())
    {
        if (Environment.UserInterActive)
        {
            service.Start();
            Thread.Sleep(Timeout.Infinite);
        }
        else
        {
            ServiceBase.Run(service);
        }
    }
