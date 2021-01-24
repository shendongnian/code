    public MyHostedService(IServiceScopeFactory serviceScopeFactory)
                : base(consumer)
            {
                _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
    
            }
    
    And inside the method use like this:
    
    using (var scope = _serviceScopeFactory.CreateScope())
                    {
                        var storageService = scope.ServiceProvider.GetRequiredService<MyService>();
    
    }
