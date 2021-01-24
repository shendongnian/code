    static class Program
    {
        static async Task Main(string[] args)
        {
            SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
            Console.WriteLine("before");
            await DoAsync().ConfigureAwait(false);
            Console.WriteLine("after");
        }
        static async Task DoAsync()
        {
            await Task.Delay(100).ConfigureAwait(false);
        }
    }
