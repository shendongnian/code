    var serviceScopeFactory = _webHost.Services.GetService<IServiceScopeFactory>();
    using (var scope = serviceScopeFactory.CreateScope())
    {
        var handler = (IEventHandler<TEvent>)scope.ServiceProvider.GetService(typeof(IEventHandler<TEvent>))
        // …
    }
