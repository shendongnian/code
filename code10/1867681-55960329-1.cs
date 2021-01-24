        public class Service : IHostedService
    {
        private readonly IHostApplicationLifetime _applicationLifetime;
        public Service(IHostApplicationLifetime applicationLifetime)
        {
            _applicationLifetime = applicationLifetime;
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            ...
            _applicationLifetime.StopApplication();
            return Task.CompletedTask;
        }
        ...
    }
