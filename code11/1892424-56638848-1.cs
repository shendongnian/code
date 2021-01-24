    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Concurrent;
    
    namespace AdvancedHost
    {
        public class LoggingService : IHostedService, IDisposable
        {
    
            public Task StartAsync(CancellationToken cancellationToken)
            {
                // Startup code
    
                return Task.CompletedTask;
            }
    
            public Task StopAsync(CancellationToken cancellationToken)
            {           
                // Stop timers, services
                return Task.CompletedTask;
            }
    
            public void Dispose()
            {
                // dispose of non-managed resources
            }
        }
    }
