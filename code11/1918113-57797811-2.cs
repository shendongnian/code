    internal class MyService : IHostedService
    {
        
        public MyService(Stuff stuff)  // injected stuff
        {
            
        }
    
        public Task StartAsync(CancellationToken cancellationToken)
        {
     
        }
    
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
