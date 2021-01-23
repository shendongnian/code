    int noofrunspersecond = 30;
    long ticks1 = 0;
    long ticks2 = 0;
    double interval = (double)Stopwatch.Frequency / noofrunspersecond;
    while (true) {
      ticks2 = Stopwatch.GetTimestamp();
      if (ticks2 >= ticks1 + interval) {
        ticks1 = Stopwatch.GetTimestamp();
        //perform your logic here
      }
      Thread.Sleep(1);
    }
