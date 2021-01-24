    public class RedisHostingRunner : HostedService
    {
        private readonly IServiceProvider _serviceProvider;
        IRedisSubscriber _subscriber;
        public RedisHostingRunner(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _subscriber = _serviceProvider.GetRequiredService<RedisSubscriber>();
        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            //while (!cancellationToken.IsCancellationRequested)
            //{
                _subscriber.SubScribeChannel();
                //await Task.Delay(TimeSpan.FromSeconds(60), cancellationToken);
            //}
        }
        public Task ShutdownAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }
    }
