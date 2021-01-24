.ConfigureServices((hostContext, services) =>
{
	...
    services.AddSingleton<IEventProcessorFactory, EventProcessorFactory>();
    services.AddSingleton<IEventProcessor, TwinChangesEventHandler>();
	...
});
 public class EventProcessorFactory : IEventProcessorFactory
 {
     private readonly IEventProcessor _fluxEventProcessor;
     public EventProcessorFactory(IEventProcessor fluxEventProcessor)
     {
         _fluxEventProcessor = fluxEventProcessor;
     }
     public IEventProcessor CreateEventProcessor(PartitionContext context)
     {
         return _fluxEventProcessor;
     }
 }
Then in your handler you can have access to the injected hub
public class TwinChangesEventHandler : IEventProcessor
{
	private readonly IHubContext<MyHub> _myHubContext;
    public TwinChangesEventHandler(IHubContext<MyHub> myHubContext)
    {
        _myHubContext= myHubContext;
    }
	
	...
	
	async Task IEventProcessor.ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
	{
		foreach (var eventData in messages)
		{
			await _myHubContext.Clients.All.SendAsync("Update", eventData);
		}
		//Call checkpoint every 5 minutes, so that worker can resume processing from 5 minutes back if it restarts.
		if (_checkpointStopWatch.Elapsed > TimeSpan.FromMinutes(5))
		{
			await context.CheckpointAsync();
			_checkpointStopWatch.Restart();
		}
	}
}
