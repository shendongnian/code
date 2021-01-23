    Stopwatch stopWatch = new Stopwatch(); 
    stopWatch.Start(); 
    
    for (int i = 0; i < 1000000; i++)
    {
        // code to be timed...
    }
    
    stopWatch.Stop(); 
    double timeForOneIteration = stopWatch.Elapsed / 1000000.0; 
