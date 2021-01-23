    // load XML Method
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    // run XML parsing code
    stopWatch.Stop();
    
    var xmlTime = stopWatch.Elapsed;
    
    
    // SQL Server dump Method
    var stopWatch = new Stopwatch();
    stopWatch.Start();
    // dump to SQL Server
    stopWatch.Stop();
    
    var sqlTime = stopWatch.Elapsed;
