    internal static class Program
    {
        private static async Task Main()
        {
            await using var obj = new TestDisposingObject();
            _ = obj.Job0Async();
            _ = obj.Job1Async(100).ContinueWith(r => Console.WriteLine(r.Result));
            Console.WriteLine("Waiting For jobs done...");
        }
    }
