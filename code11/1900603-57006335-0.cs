    class Program
    {
        private static readonly ConcurrentQueue<(string Data, TaskCompletionSource<bool> Tcs)> Queue = new ConcurrentQueue<(string Data, TaskCompletionSource<bool> Tcs)>();
    
        static void Main()
        {
            var cts = new CancellationTokenSource();
            Task.Run(() => ProcessQueue(cts.Token), cts.Token);
    
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "q")
                {
                    cts.Cancel();
                    break;
                }
    
                var tcs = new TaskCompletionSource<bool>();
                Queue.Enqueue((input, tcs));
    
                Console.WriteLine("waiting...");
                tcs.Task.GetAwaiter().GetResult();
                //TODO in normal async method you should write: await tcs.Task;
                Console.WriteLine("waited");
            }
        }
    
        private static void ProcessQueue(CancellationToken ct)
        {
            while (true)
            {
                ct.ThrowIfCancellationRequested();
    
                if (!Queue.TryDequeue(out var item))
                {
                    continue;
                }
    
                //emulate work
                Thread.Sleep(1000);
                Console.WriteLine($"processed {item.Data}");
                item.Tcs.SetResult(true);
            }
        }
    }
