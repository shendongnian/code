    int tRuns = 1000000;
    List<String> tList = new List<string>();
    
    for (int i = 0; i < tRuns; i++)
       tList.Add(i.ToString());
    
    
    PerformanceMeter.Start();
    int tSum = 0;
    for (int i = tRuns-1; i >= 0; i--)
    {
       tSum += Convert.ToInt32(tList[i]);
    }
    
    PerformanceMeter.LogAndStop("using Convert.ToInt32:");
    
    cLogger.Debug("tSum:" + tSum);
    PerformanceMeter.Start();
    
    tSum = 0;
    for (int i = tRuns-1; i >= 0; i--)
    {
       tSum += Int32.Parse(tList[i]);
    }
    
    PerformanceMeter.LogAndStop("using Int32.Parse:");
    cLogger.Debug("tSum:" + tSum);
