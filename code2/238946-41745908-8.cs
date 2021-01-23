    public void Configure(IApplicationLifetime lifetime)
    {
        var quartz = new JobScheduler(Kernel);
        lifetime.ApplicationStarted.Register(quartz.Start);
        lifetime.ApplicationStopping.Register(quartz.Stop);
    }
