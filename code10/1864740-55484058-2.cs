    public class TestService2 : BackgroundService
    {
        private readonly IApplicationLifetime _applicationLifetime;
        public TestService2(IApplicationLifetime applicationLifetime)
        {
            _applicationLifetime = applicationLifetime;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!_applicationLifetime.ApplicationStopping.IsCancellationRequested)
                {
                    await Task.Delay(100, _applicationLifetime.ApplicationStopping);
                    Console.WriteLine("running service 2");
                }
            }
            catch (ApplicationException)
            {
                _applicationLifetime.StopApplication();
            }
        }
    }
