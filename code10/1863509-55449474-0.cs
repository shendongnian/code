    stopWatch = Stopwatch.StartNew();
    context.Projects.AsNoTracking().SingleOrDefault(p => p == -1); // record does not exist
    stopWatch.Stop();
    Debug.WriteLine($"AsNoTracking().SingleOrDefaultAsync, by ID: {stopWatch.ElapsedMilliseconds}");
    
    stopWatch = Stopwatch.StartNew();
    context.Projects.AsNoTracking().SingleOrDefault(p => p == -2); // record does not exist
    stopWatch.Stop();
    Debug.WriteLine($"AsNoTracking().SingleOrDefaultAsync, by ID: {stopWatch.ElapsedMilliseconds}");
