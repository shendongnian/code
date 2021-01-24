        static void Main()
        {
            Console.WriteLine("Main starting.");
    
            ThreadPool.QueueUserWorkItem(
                new WaitCallback(WorkMethod), autoEvent);
    
            // Wait for work method to signal.
            if(autoEvent.WaitOne(1000))
            {
                Console.WriteLine("Work method signaled.");
            }
            else
            {
                Console.WriteLine("Timed out waiting for work " +
                    "method to signal.");
            }
            Console.WriteLine("Main ending.");
        }
    
        static void WorkMethod(object stateInfo) 
        {
            Console.WriteLine("Work starting.");
    
            // Call your external dll here
            program.Call(parameters);
    
            // Signal that work is finished.
            Console.WriteLine("Work ending.");
            ((AutoResetEvent)stateInfo).Set();
        }
