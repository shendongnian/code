    var lastKeyTime = DateTime.Now;
    ...
    while (true)
    {
       if (Console.KeyAvailable())
       {
          lastKeyTime = DateTime.Now;
          // Read and process key
       }
       else
       {
          if (DateTime.Now - lastKeyTime  > timeoutSpan)
          {
             lastKeyTime = DateTime.Now;
             // lose a live
          }
       }
       Thread.Sleep(50);  // from 1..500 will work
    }
