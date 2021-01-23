    class Program
    {
        static int DivideBy(int divisor) 
        { 
          Thread.Sleep(2000);
          return 10 / divisor; 
        }
        static void Main(string[] args)
        {
            const int value = 0;
            var exceptionTask = new Task<int>(() => DivideBy(value));
            exceptionTask.ContinueWith(result => Console.WriteLine("Faulted ..."), TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.AttachedToParent);
            exceptionTask.ContinueWith(result => Console.WriteLine("Success ..."), TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.AttachedToParent);
            exceptionTask.Start();
            try
            {
                exceptionTask.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Exception: {0}", ex.InnerException.Message);
            }
            
            Console.WriteLine("Press <Enter> to continue ...");
            Console.ReadLine();
        }
