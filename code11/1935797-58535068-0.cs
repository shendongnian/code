csharp
public class BackgroundServiceStarter<T> : IHostedService where T : IHostedService
{
	readonly T _backgroundService;
	public BackgroundServiceStarter(T backgroundService)
	{
		_backgroundService = backgroundService;
	}
	public Task StartAsync(CancellationToken cancellationToken)
	{
		return _backgroundService.StartAsync(cancellationToken);
	}
	public Task StopAsync(CancellationToken cancellationToken)
	{
		return _backgroundService.StopAsync(cancellationToken);
	}
}
then register them to the DI container in `ConfigureServices`:
csharp
// make the classes injectable
services.AddSingleton<FirstProcessingSystem>();
services.AddSingleton<SecondProcessingSystem>();
// start them up
services.AddHostedService<BackgroundServiceStarter<FirstProcessingSystem>>();
services.AddHostedService<BackgroundServiceStarter<SecondProcessingSystem>>();
Now that you got all that set up correctly, you can simply inject a reference to your signalR hub using `IHubContext<TestHub> context` in the constructor parameters of whatever class that needs it (as described in some of the links you posted).
  [1]: https://stackoverflow.com/a/51314147/9423721
