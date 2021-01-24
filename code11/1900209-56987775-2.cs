    internal static class Program
    {
        public static async Task Main()
        {
            var future = new Future(success: true);
    
            var result = await future.ToAsync();
    
            Console.WriteLine(result);
    
            var future2 = new Future(success: false);
    
            try
            {
                var result2 = await future2.ToAsync();
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e.InnerException.Message);
            }
        }
    }
