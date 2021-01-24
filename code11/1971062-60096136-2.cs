     public class MyService : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("test");
                //await run job
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("start");
            await ExecuteAsync(cancellationToken);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("stop");
            return Task.CompletedTask;
        }
    }
