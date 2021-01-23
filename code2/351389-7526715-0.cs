    if we have to use same function then i would have to implement multiple time? like this:
    
    using System;
    using System.Threading;
    public class mythread
    {
        public static void Main()
        {
            // Queue the task.
            Console.WriteLine(DateTime.Now);
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc1));
            //ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc2));
    
            Console.WriteLine("Main thread does some work, then sleeps.");
            // If you comment out the Sleep, the main thread exits before
            // the thread pool task runs.  The thread pool uses background
            // threads, which do not keep the application running.  (This
            // is a simple example of a race condition.)
            Thread.Sleep(1000);
    
            Console.WriteLine("Main thread exits.");
            Console.WriteLine(DateTime.Now);
            Console.Read();
        }
    
        // This thread procedure performs the task.
        static void ThreadProc1(object obj)
        {
            // No state object was passed to QueueUserWorkItem, so 
            // stateInfo is null.
            Console.WriteLine("Hello world!!,this is ONE.");
        }
        static void ThreadProc2(object obj)
        {
            // No state object was passed to QueueUserWorkItem, so 
            // stateInfo is null.
            Console.WriteLine("Hello world!!,this is TWO.");
        }
    }
