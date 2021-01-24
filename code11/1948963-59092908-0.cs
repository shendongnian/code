    public class Worker : BackgroundService
    {
        private readonly IHostApplicationLifetime _hostLifetime;
    
        public Worker(IHostApplicationLifetime hostLifetime) 
        {
            _hostLifetime = hostLifetime;    
        }
    
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                DoWork();
                if (RunOnlyOnce())
                {
                    _hostLifetime.StopApplication();
                }
            }
        }
    }
