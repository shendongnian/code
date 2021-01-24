    void Loop()
    {
         int ticks = 0;
         var stopwatch = new Stopwatch();
         while(true)
         {
            stopwatch.Start();
            if(ticks % 20 == 0) // Once every 20 ticks (or 200 ms)
            {
                DrawGraphics();
            }
            if(ticks % 50 == 0) // Once every 50 ticks (or 500 ms)
            {
                ProcessKeyPresses();
            }
            ticks++;
            stopwatch.Stop();
            Thread.Sleep(10 - stopwatch.TotalMilliseconds); // Wait until at least 10 milliseconds have passed
         }
    }
