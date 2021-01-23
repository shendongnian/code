    class ThreadTest 
    {
         static void Main()
         {
             Thread t = new Thread(WriteY);
              // Kick off a new thread
             t.Start();
             // running WriteY()
             // Simultaneously, do something on the main thread.
             for (int i = 0; i < 10000000; i++)
             {
                  Console.Write("x");
                  Console.ReadLine();     
             }
         }     
    
        static void WriteY()
        {
             for (int i = 0; i < 10000000; i++) 
             {
                   Console.Write("y");
                   Thread.Sleep(1000); // let the thread `sleep` for one seconds before running.     
             } 
        } 
    }
