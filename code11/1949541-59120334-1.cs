      public class HostedService1 : IHostedService
      {
            private readonly IOptionsMonitor<HostedServiceConfig> _options;
    
            public HostedService1(IOptionsMonitor<HostedServiceConfig> options)
            {
                _options = options;
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
