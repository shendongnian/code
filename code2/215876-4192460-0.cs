    private static void Main(string[] args)
        {
          var shouldExit = new AutoResetEvent(false);
    
          ThreadPool.QueueUserWorkItem(
            delegate
            {
              while (true)
              {
                Console.WriteLine("Running...");
                
                if (shouldExit.WaitOne(0))
                  break;
              }
    
              Console.WriteLine("Done.");
            }
            );
        
          // wait a bit
          Thread.Sleep(1000);      
          shouldExit.Set();
    
          Console.ReadLine();
        }
