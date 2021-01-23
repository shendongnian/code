    using System.Diagnostics;
    ...
    
    Stopwatch watch = new Stopwatch();
    watch.Start();
    
    // here the complex program.
    ...
    
    watch.Stop();
    
    TimeSpan timeSpan = watch.Elapsed;
    
    Console.WriteLine("Time: {0}h {1}m {2}s {3}ms", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);
