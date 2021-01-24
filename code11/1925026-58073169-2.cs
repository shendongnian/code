    static void Main(string[] args)
    {
        try
        {
            ProcessTask()
               .GetAwaiter()
               .GetResult(); // This will give you a better exception details compared to Task.Wait().
        }
        catch (Exception ex)
        {
            Console.WriteLine($"There was an exception: {ex.ToString()}");
    #if DEBUG
            Console.ReadLine(); // Generic error handler. Stop exiting. So you can read the exception. 
    #endif
        }
    }
