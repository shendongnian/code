    using(var threadLifeTime = AutofacDependencyResolver.Current.ApplicationContainer.BeginLifetimeScope())
    {
        _lifeTimeScopeChild = threadLifeTime;
        Thread t = new Thread(new ParameterizedThreadStart(MySeparateThread));
        t.Start(id);  
    }
