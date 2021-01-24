    public class TestService : BackgroundService
    {
        private readonly IApplicationLifetime _applicationLifetime;
        public TestService(IApplicationLifetime applicationLifetime)
        {
            _applicationLifetime = applicationLifetime;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!_applicationLifetime.ApplicationStopping.IsCancellationRequested)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1), _applicationLifetime.ApplicationStopping);
                    Console.WriteLine("running service 1");
                    throw new ApplicationException("OOPS!!");
                }
            }
            catch (ApplicationException)
            {
                _applicationLifetime.StopApplication();
            }
        }
    }
