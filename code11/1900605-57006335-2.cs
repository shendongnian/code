    class Program
    {
        private static readonly ConcurrentQueue<(string Data, TaskCompletionSource<string> Tcs)> Queue = new ConcurrentQueue<(string Data, TaskCompletionSource<string> Tcs)>();
    
        static void Main()
        {
            var cts = new CancellationTokenSource();
            Task.Run(() => ProcessQueue(cts.Token), cts.Token);
            ListenForTasks().GetAwaiter().GetResult();
            cts.Cancel();
        }
    
        private static async Task ListenForTasks()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "q")
                {
                    break;
                }
    
                var tcs = new TaskCompletionSource<string>();
                Queue.Enqueue((input, tcs));
    
                Console.WriteLine("waiting...");
                var result = await tcs.Task;
                Console.WriteLine($"waited: {result}");
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
                item.Tcs.SetResult(item.Data + "_PROCESSED");
            }
        }
    }
