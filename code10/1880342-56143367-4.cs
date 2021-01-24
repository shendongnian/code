    internal static class Program
    {
        private static async Task Main()
        {
            var result0 = default(Task);
            var result1 = default(Task);
            var obj = new TestDisposingObject();
            result0 = obj.Job0Async();
            result1 = obj.Job1Async(100).ContinueWith(r => Console.WriteLine(r.Result));
            obj.Dispose();
            Console.WriteLine("Waiting For jobs done...");
            await Task.WhenAll(result0, result1);
        }
    }
