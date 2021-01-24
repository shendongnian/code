        public static async Task RunAsync(this IHost host, CancellationToken token = default)
        {
            try
            {
                await host.StartAsync(token);
                await host.WaitForShutdownAsync(token);
            }
            finally
            {
    #if DISPOSE_ASYNC
                if (host is IAsyncDisposable asyncDisposable)
                {
                    await asyncDisposable.DisposeAsync();
                }
                else
    #endif
                {
                    host.Dispose();
                }
            }
        }
