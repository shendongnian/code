    class Program
    {
        static void Main(string[] args)
        {
            using (var cts = new CancellationTokenSource())
            {
                ThreadPool.QueueUserWorkItem(DoSomethingOnAnotherThread, cts.Token);
                // This is just for demonstration. It allows the other thread to run for a little while
                // before it gets canceled.
                Thread.Sleep(5000);
                cts.Cancel();
            }
        }
        private static void DoSomethingOnAnotherThread(object obj)
        {
            var cancellationToken = (CancellationToken) obj;
            // This thread does its thing. Once in a while it does this:
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
            // Keep doing what it's doing.
        }
    }
