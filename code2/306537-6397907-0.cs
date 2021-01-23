    var cb = new ConatainerBuilder();
    cb.Register(c => 
    {
        var settings = GetSettings();
        if(settings is FooSettings)
            return new FooProcessor((FooSettings)settings);
        else if(settings is BarSettings)
            return new BarProcessor((BarSettings)settings);
        else
           throw new NotImplementedException("Hmmm. Got some new fangled settings.");
    }).As<IProcessConsumer>();
