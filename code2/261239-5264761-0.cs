       class Program
       {
          static AutoResetEvent _ready = new AutoResetEvent(false);
          static AutoResetEvent _go = new AutoResetEvent(false);
          static Object _locker = new Object();
          static string _message = "Start";
    
          static AutoResetEvent _exitClient = new AutoResetEvent(false);
          static AutoResetEvent _exitWork = new AutoResetEvent(false);
    
          static void Main()
          {
             new Thread(Work).Start();
             new Thread(Client).Start();
    
             Thread.Sleep(3000); // Run for 3 seconds then finish up
    
             _exitClient.Set();
             _exitWork.Set();
             _ready.Set(); // Make sure were not blocking still
             _go.Set();
          }
    
          static void Client()
          {
             List<string> messages = new List<string>() { "ooo", "ahhh", null };
             int i = 0;
             while (!_exitClient.WaitOne(0))       // Gracefully exit if triggered
             {
                _ready.WaitOne();                  // First wait until worker is ready
                lock (_locker) _message = messages[i++];
                _go.Set();                         // Tell worker to go
                if (i == 3) { i = 0; }
             }
          }
    
          static void Work()
          {
             while (!_exitWork.WaitOne(0))             // Gracefully exit if triggered
             {
                _ready.Set();                          // Indicate that we're ready
                _go.WaitOne();                         // Wait to be kicked off...
                lock (_locker)
                {
                   if (_message != null)
                   {
                      Console.WriteLine(_message);
                   }
                }
             }
          }
       }
