    class Program
    {
        async static Task Main(string[] args)
        {
            await TryExecuteAsync(AsyncFunction);
            Console.WriteLine("Finished without unhandled exception.");
        }
        private async static Task AsyncFunction()
        {
            Console.WriteLine("AsyncFunction starting");
            await Task.Run(() =>
            {
                Console.WriteLine("Sleep starting");
                Thread.Sleep(3000);
                Console.WriteLine("Sleep end");
                throw new Exception();
            });
            Console.WriteLine("AsyncFunction end");
        }
        
        private async static Task TryExecuteAsync(Func<Task> asyncAction)
        {
            try
            {
                await asyncAction();
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }
        private static void Log(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
