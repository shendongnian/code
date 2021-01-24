    public override void Configure(Funq.Container container)
    {
        var serverEventsFeature = new ServerEventsFeature();
        // bind server events
    	serverEventsFeature.Register(this);			
        container.AddSingleton(new Engine(container.Resolve<IServerEvents>()));
    }
