    public class Program
    {
        public static ExternalResourceHandler _erh = new ExternalResourceHandler();
        
        static int Main()
        {
            Console.WriteLine("Type 'exit' to stop; 'parallel', 'pool' or 'thread' for the corresponding execution version.");
            string input = Console.ReadLine();
            while(input != "exit")
            {
                switch(input)
                {
                case "parallel":
                    // Run the Parallel.For version
                    ParallelForVersion();
                    break;
                caase "pool":
                    // Run the threadpool version
                    ThreadPoolVersion();
                    break;
                case "thread":
                    // Run the thread version
                    ThreadVersion();
                    break;
                default:
                    break;
                }
                input = Console.ReadLine();
            }
            return 0;
        }
    
        public static void ParallelForVersion()
        {
            Parallel.For(0, 1, i =>
            {
                _erh.PerformExternalOperation();
            });
        }
        
        public static void ThreadPoolVersion()
        {
            ThreadPool.QueueUserWorkItem(o=>
            {
                _erh.PerformExternalOperation();
            });
        }
        
        public static void ThreadVersion()
        {
            Thread t = new Thread(()=>
            {
                _erh.PerformExternalOperation();
            });
            t.IsBackground = true;
            t.Start();
        
        }
    }
