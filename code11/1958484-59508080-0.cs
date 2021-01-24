        static async Task OtherLoggerAsync(CancellationToken ct)
        {
            await Task.Yield();
            // This method is now running on it's own thread
            while (true)
            {
                Log.Information("Other logger logged on thread");
                await Task.Delay(750); // Mimic some work
                if (ct.IsCancellationRequested)
                {
                    Log.Logger.Information("OtherLoggerAsync() exiting");
                    break;
                }
            }
        }
        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                // Create the cancellation token
                var ct = cts.Token;
                // Start the other logger with the cancellation token
                var t = OtherLoggerAsync(ct);
            
                // Still in the main thread
                for (var i = 0; i < 10; i++)
                {
                    Log.Logger.Information("Main thread logged");
                    await Task.Delay(1000); // Mimic some work
                }
                // Main thread has finished.  We want to stop the OtherLogger Thread
                // if it has finsihed or not.
                // signal the cancellation
                cts.Cancel();
                // wait for it to finish
                Task.WaitAll(t);
                Log.Logger.Information("Main thread exiting");
                Log.CloseAndFlush();
            }
        }
