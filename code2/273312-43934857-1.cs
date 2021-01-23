    using System;
    using System.Threading;
    
    class WaitOne
    {
        static AutoResetEvent autoEvent = new AutoResetEvent(false);
        static Exception SavedException = null;
        static void Main()
        {
            Console.WriteLine("Main starting.");
    
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(WorkMethod), autoEvent);
    
            // Wait for work method to signal.
            autoEvent.WaitOne();
            if (SavedException != null)
            {
               // handle this exception as you want
            }
            Console.WriteLine("Work method signaled.\nMain ending.");
        }
    
        static void WorkMethod(object stateInfo) 
        {
            Console.WriteLine("Work starting.");
    
            // Simulate time spent working.
            try
            {
              Thread.Sleep(new Random().Next(100, 2000));
              throw new Exception("Test exception");
            }
            catch (Exception ex)
            {
                SavedException = ex;
            }            
    
            // Signal that work is finished.
            Console.WriteLine("Work ending.");
            ((AutoResetEvent)stateInfo).Set();
        }
    }
