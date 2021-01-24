Thread.CurrentThread.IsBackground = false;
That line will not do anything since there are no further instructions to wait for.
Simply add `Console.ReadLine()` and the end of Main.
    static void Main()
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(Method_1));
        ThreadPool.QueueUserWorkItem(new WaitCallback(Method_2));
        ThreadPool.QueueUserWorkItem(new WaitCallback(Method_3));
        Console.Write("Press ENTER to quit");
        Console.ReadLine();
    }
If you want to wait for all threads to complete, you can use thread synchronization objects like `ManualResetEvent`.
    using System;
    using System.Threading;
    
    namespace ThreadingInCSharp
    {
        class Program
        {
    	    ManualResetEvent _method1Event = new ManualResetEvent(false);
    	    ManualResetEvent _method2Event = new ManualResetEvent(false);
    	    ManualResetEvent _method3Event = new ManualResetEvent(false);
    		
            static void Main()
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(Method_1));
                ThreadPool.QueueUserWorkItem(new WaitCallback(Method_2));
                ThreadPool.QueueUserWorkItem(new WaitCallback(Method_3));
                
    			WaitHandle.WaitAll(new[]{_method1Event, _method2Event, _method3Event});
            }
    
            private static void Method_1(object obj)
            {
                for (int i = 0; i < 9000; i++)
                {
                    Console.WriteLine("It's method 1");
                }
    			
    			_method1Event.Set();
            }
    		
            private static void Method_2(object obj)
            {
                Console.WriteLine("It's method 2");
    
    			_method2Event.Set();
    		}
    		
            private static void Method_3(object obj)
            {
                Console.WriteLine("It's method 3");
    			
    			_method3Event.Set();
            }
        }
    }
`WaitHandle.WaitAll` will wait until all three events have been signaled (i.e. the methods have completed their work). 
