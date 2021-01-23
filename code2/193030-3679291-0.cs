    var cat = new PerformanceCounterCategory("Process");
    
    var names = cat.GetInstanceNames();
    
    foreach (var name in names.OrderBy(n => n))
    {
        var pidCounter = new PerformanceCounter("Process", "ID Process", name, true);
        var sample = pidCounter.NextSample();
        Console.WriteLine(name + ": " + sample.RawValue);
    }
