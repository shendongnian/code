    class Program
    {
        static void Main(string[] args)
        {
            Exception exception = null;
            Thread thread = new Thread(() => SafeExecute(Test, Handler));
            thread.Start();            
            
            Console.ReadLine();
        }
    
        private static void Handler(Exception exception)
        {        
            Console.WriteLine(exception);
        }
    
        private static void SafeExecute(Action test, Action<Exception> handler)
        {
            try
            {
                test();
            }
            catch (Exception ex)
            {
                handler(ex);
            }
        }
    
        static void Test()
        {
            throw new Exception();
        }
    }
