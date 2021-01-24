      public class HostedService1 : IHostedService
      {
            private readonly IOptionsMonitor<HostedServiceConfig> _options;
            private CancellationToken _cancellationToken;
            public HostedService1(IOptionsMonitor<HostedServiceConfig> options)
            {
                _options = options;
                 // Or listen to changes and re-run all services from one place inside `Configure` method of `Startup`
                _options.OnChange(async x =>
                {
                    if (x.RunService1)
                    {
                        await StartAsync(_cancellationToken);
                    }
                });
            }
    
            public Task StartAsync(CancellationToken cancellationToken)
            {
                if(_cancellationToken == null) 
                {
                     _cancellationToken = cancellationToken;
                }
             
                Task.Run(async () =>
                {
                    while (!_cancellationToken .IsCancellationRequested || !_options.CurrentValue.RunService1)
                    {
                         ....
                    }
                });
    
                return Task.CompletedTask;
            }
    
            ...
       }
