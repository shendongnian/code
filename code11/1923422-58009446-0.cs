    internal class Program
    {
        private static void Main()
        {
            var source = new CancellationTokenSource();
            var token = source.Token;
            Task.Run(() =>
            {
                Parallel.ForEach(Enumerable.Range(1, 100), new ParallelOptions {CancellationToken = token},
                    i =>
                    {
                        for (var y = 0; y < 100; y++)
                        {
                            token.ThrowIfCancellationRequested();
                            Thread.Sleep(1000);
                            Console.WriteLine($"{i} {y}");
                        }
                    });
            }, token);
            Console.WriteLine("press return to cancel...");
            Console.ReadLine();
            source.Cancel();
            Console.WriteLine("press return to exit...");
            Console.ReadLine();
        }
    }
