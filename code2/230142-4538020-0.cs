    public class Example2
    {
        // Declaration - Take 1 parameter, return nothing
        public delegate void LogHandler(string message);
    
        // Instantiation - Create a function which takes delegate as one parameter
        // Verify if it is null before you use it
        public void Process(LogHandler logHandler)
        {
            if (logHandler != null)
            {
                logHandler("Process() begin");
            }
    
            if (logHandler != null)
            {
                logHandler("Process() end");
            }
        }
    }
    
    public class Example2DelegateConsumer
    {
        // Create a method with the same signature as the delegate
        static void Logger(string s)
        {
            Console.WriteLine(s);
        }
    
        public static void Main(string[] args)
        {
            Example2 ex2 = new Example2();
    
            // Invocation in the client
            Example2.LogHandler myLogger = new Example2.LogHandler(Logger);
            ex2.Process(myLogger);
        }
    }
