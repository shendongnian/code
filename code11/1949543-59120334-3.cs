      public class HostedService1 : IHostedService
      {
            private readonly IOptionsMonitor<HostedServiceConfig> _options;
    
            public HostedService1(IOptionsMonitor<HostedServiceConfig> options)
            {
                _options = options;
                 // Or listen to changes and re-run all services from one place inside `Configure` method of `Startup`
                _options.OnChange(async x =>
                {
                    if (x.RunService1)
                    {
                        await StartAsync(new CancellationTokenSource().Token);
                    }
                });
            }
    
            public Task StartAsync(CancellationToken cancellationToken)
            {
                Task.Run(async () =>
                {
                    while (!cancellationToken.IsCancellationRequested || !_options.CurrentValue.RunService1)
                    {
                         ....
                    }
                });
    
                return Task.CompletedTask;
            }
    
            ...
       }
