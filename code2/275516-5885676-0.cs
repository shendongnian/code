    class Program
    {
        static int DivideBy(int divisor) { return 10 / divisor; }
        static void Main(string[] args)
        {
            var value = 0;
            var exceptionTask = new Task<int>(() => DivideBy(value));
            exceptionTask.ContinueWith(result => Console.WriteLine("Faulted ..."), TaskContinuationOptions.OnlyOnFaulted);
            exceptionTask.ContinueWith(result => Console.WriteLine("Success ..."), TaskContinuationOptions.OnlyOnRanToCompletion);
            exceptionTask.Start();
            Console.WriteLine("Press <Enter> to continue ...");
            Console.ReadLine();
        }
