    public class EventBusHostedService : IHostedService {
        private readonly IConsumeEventBus eventBus;
        
        public EventBusHostedService(IConsumeEventBus eventBus) {
            this.eventBus = eventBus;
        }
        
        public Task StartAsync(CancellationToken cancellationToken) {
            eventBus.Subscribe<DemoEvent, DemoEventHandler>("18Julyexchange", "18Julyqueue", "18JulyRoute");
        
            return Task.CompletedTask;
        }
        public Task StopAsync(CancellationToken cancellationToken) {
            return Task.CompletedTask;
        }
    }
    
