    DateTime start = DateTime.UtcNow;
    
    int i = 1;
    while (i <= 100) {
    
      int limit = (int)((DateTime.UtcNow - start).TotalSeconds * 5.0);
    
      if (i <= limit) {
    
        Console.WriteLine(i);
        i++;
    
      } else {
        Thread.Sleep(100);
      }
    
    }
