    public class MyJobBackgroundService : BackgroundService
    {
        private readonly ILogger<MyJobBackgroundService> _logger;
        private readonly JobQueue<MyJob> _queue;
        public MyJobBackgroundService(ILogger<MyJobBackgroundService> logger, JobQueue<MyJob> queue)
        {
            _logger = logger;
            _queue = queue;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var job = await _queue.DequeueAsync(stoppingToken);
                // do stuff
                _logger.LogInformation("Working on job {JobId}", job.Id);
                await Task.Delay(2000);
            }
        }
    }
