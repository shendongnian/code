    var watch = System.Diagnostics.Stopwatch.StartNew();
    
    for()
    {
     // ..
    }
    
    watch.Stop();
    // Format 00:00:02.0001008
    string elapsed = watch.Elapsed.ToString();     
    // Milliseconds like 2000 for 2 seconds
    string elapsedMs = watch.ElapsedMilliseconds.ToString(); 
    System.Diagnostics.Debug.WriteLine(elapsed);
