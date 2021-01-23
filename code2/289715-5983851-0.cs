    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = new Task<int>(Test);
            task.ContinueWith(ExceptionHandler);
            task.Start();
            Console.ReadLine();
        }
    
        static int Test()
        {
            throw new Exception();
        }
    
        static void ExceptionHandler(Task<int> task)
        {
            var exception = task.Exception;
            Console.WriteLine(exception);
        }
    }
