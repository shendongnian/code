    using System;
    using System.Threading;
    
    class Test
    {
        static void Main()
        {
            int worker; 
            int ioCompletion;
            ThreadPool.GetMaxThreads(out worker, out ioCompletion);
            Console.WriteLine("{0} / {1}", worker, ioCompletion);
        }    
    }
