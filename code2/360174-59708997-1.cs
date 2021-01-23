    using Microsoft.Extensions.Hosting;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApp
    {
        public class Worker : BackgroundService
        {
            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {
                //do some operation
            }
    
            public override Task StartAsync(CancellationToken cancellationToken)
            {
                return base.StartAsync(cancellationToken);
            }
    
            public override Task StopAsync(CancellationToken cancellationToken)
            {
                return base.StopAsync(cancellationToken);
            }
        }
    }
