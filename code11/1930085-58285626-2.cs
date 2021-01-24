    public class Program
    {
        public static CancellationTokenSource tokenSource;
        private static async Task Main(string[] args)
        {
            while (true)
            {
                await Work();
            }
        }
        public static async Task Work()
        {
            tokenSource = new CancellationTokenSource();
            Console.WriteLine("Press any key to START doing work");
            Console.ReadLine();
            Console.WriteLine("Press any key to STOP doing work");
            var task = DoWork(tokenSource.Token);
            Console.ReadLine();
            Console.WriteLine("Stopping...");
            tokenSource.Cancel();
            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
                // Task was cancelled
            }
        }
        public static async Task DoWork(CancellationToken cancelToken)
        {
            while (true)
            {
                Console.WriteLine("Working...");
                await Task.Run(() =>
                {
                    Thread.Sleep(1500);
                });
                cancelToken.ThrowIfCancellationRequested();
            }
        }
    }
