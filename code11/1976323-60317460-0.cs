	public class MessagingService : IHostedService, IDisposable
	{
		public MessagingService(ConnectionSettings connectionSettings,
			AppSubscriberSettings subscriberSettings,
			MessageHandlerTypeMapping[] messageHandlerTypeMappings,
			ILogger<MessagingService> logger)
		{
			....
		}
		public async Task StartAsync(CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			await Task.WhenAll(subscribers.Value.Select(s => s.StartSubscriptionAsync()));
		}
		public async Task StopAsync(CancellationToken cancellationToken)
		{
			...
		}
		public void Dispose()
		{
			...
		}
	}
