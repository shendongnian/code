    var m = new ManualResetEvent(false);
    // do something
    foreach (var url in urls)
    {
      Console.WriteLine("starting thread: " + url); 
      ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(myMethod), url);
    }
    m.WaitOne();
    private static void myMethod(object obj)
    {
      try{
       // do smt
      }
      finally {
        m.Set();
      }
    }
