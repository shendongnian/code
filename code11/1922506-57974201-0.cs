    class Program
    {
        static async Task Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource(100);
            await GeneralDoJobAndCatchException(() => DoJob(cts.Token));
            Console.WriteLine("Successfully finished");
        }
        private static async Task GeneralDoJobAndCatchException(Func<Task> func)
        {
            try
            {
                await func();
            }
            catch (OperationCanceledException) { }
            catch (Exception e)
            {
                Console.WriteLine("Do error handling");
            }
        }
        private static async Task DoJob(CancellationToken ct)
        {
            await Task.Delay(1000, ct);
        }
    }
