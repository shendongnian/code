    using System;
    using System.Threading;
    
    public class Test
    {
        static void Main()
        {
            for (int x = 0; x < 10; x++)
            {
                new Thread(Count).Start();
            }
        }
        
        static void Count()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine("Thread {0} starting", threadId);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("{0}: {1}", threadId, i);
            }
            Console.WriteLine("Thread {0} ending", threadId);
        }
    }
