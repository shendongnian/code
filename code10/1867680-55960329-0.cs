        public class Service : IHostedService
    {
        private readonly IApplicationLifetime _applicationLifetime;
        public Service(IApplicationLifetime applicationLifetime)
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
