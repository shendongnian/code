    public static class TimeLimitedTaskFactory
    {
        public static Task StartNew<T>(Action<CancellationToken> action, int maxTime)
        {
            Task tsk = Task.Factory.StartNew(() =>
            {
                var cts = new CancellationTokenSource();
                Timer timer = new Timer(o =>
                {
                    cts.Cancel();
                    Console.WriteLine("Cancelled!");
                }, null, maxTime, int.MaxValue);
                action(cts.Token); 
            });
            return tsk;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int maxTime = 2000;
            int maxWork = 10;
            Task tsk = TimeLimitedTaskFactory.StartNew<int>((ctx) => DoWork(ctx, maxWork), maxTime);
            Console.WriteLine("Waiting on Task...");
            tsk.Wait();
            Console.WriteLine("Finished...");
            Console.ReadKey();
        }
        static void DoWork(CancellationToken ctx, int workSize)
        {
            int i = 0;
            while (!ctx.IsCancellationRequested && i < workSize)
            {
                Thread.Sleep(500);
                Console.WriteLine("  Working on ", ++i);
            }
        }
    }
