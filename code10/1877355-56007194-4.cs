    public void ConfigureServices(IServiceCollection services)
	{
        ...
        services.AddHostedService<MyHostedService>();
        ...
    }
    public class MyHostedService : IHostedService
    {
        private Timer _timer;
        private IInjectedService _myInjectedService;
    
        public MyHostedService(IServiceProvider services)
        {
            var scope = services.CreateScope();
    
            _myInjectedService = scope.ServiceProvider.GetRequiredService<IInjectedService>();
        }
    
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
    
            return Task.CompletedTask;
        }
    
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
    
            return Task.CompletedTask;
        }
    
        private async void DoWork(object state)
        {
            _myInjectedService.DoStuff();
        }
    }
