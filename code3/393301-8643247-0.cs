    Stopwatch stopWatch = new Stopwatch(); 
    stopWatch.Start(); 
    //instead of this there is line of code that you are going to execute
     Thread.Sleep(10000); 
     stopWatch.Stop(); 
    // Get the elapsed time as a TimeSpan value. 
     TimeSpan ts = stopWatch.Elapsed; string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10); 
