    class Program
    {
        static void Main(string[] args)
        {
			List<int> data = ParallelEnumerable.Range(1, 10000).ToList();
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            Task cancelTask = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(1000);
                    tokenSource.Cancel();
                });
            ParallelOptions options = new ParallelOptions()
            {
                CancellationToken = tokenSource.Token
            };
            //parallel foreach cancellation
            try
            {
                Parallel.ForEach(data,options, (x, state) =>
                {
                    Console.WriteLine(x);
                    Thread.Sleep(100);
                });
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("Operation Cancelled");
            }
            Console.ReadLine();
        }
    }
