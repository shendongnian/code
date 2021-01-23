        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch(); 
        sw.Start();         
        System.Threading.Thread.Sleep(TimeSpan.FromSeconds(1));         
        sw.Stop();         
        // don't load a TimeSpan with ElapsedTicks, these have diff frequency,
        // call Elapsed instead to get TimeSpan.
        TimeSpan t = sw.Elapsed;         
        Console.WriteLine(t.ToString());         
        Console.ReadKey(); 
