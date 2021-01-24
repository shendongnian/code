    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Policy
                     .Handle<Exception>()
                     .WaitAndRetry(
                        retryCount: 2,
                        sleepDurationProvider: t => TimeSpan.FromSeconds(5),
                        onRetry: (ex, t, i, c) => {
                            Console.WriteLine("OnRetry");
                        }
                     )
                     .Execute(() => ErrorMethod());
                Console.WriteLine("We never get here");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception Handler");
            }
        }
        private static void ErrorMethod()
        {
            throw new InvalidOperationException("Badness");
        }
    }
