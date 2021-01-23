    for (int i = 1; i <= 100; i++ ) {
    
      DateTime start = DateTime.UtcNow;
    
      Console.WriteLine(i);
    
      int left = (int)(start.AddSeconds(1.0 / 5.0) - DateTime.UtcNow).TotalMilliseconds;
      if (left > 0) {
        Thread.Sleep(left);
      }
    
    }
