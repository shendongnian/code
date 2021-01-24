    public static class Program
    {
        public static async Task Main()
        {
            const int mainDelayInMs = 500;
            AsyncVoidMethod();
            await Task.Delay(mainDelayInMs);
            Console.WriteLine($"end of {nameof(Main)}");
        }
        static async void AsyncVoidMethod()
        {
            await Task.Delay(1000);
            Console.WriteLine($"end of {nameof(AsyncVoidMethod)}");
        }
    }
