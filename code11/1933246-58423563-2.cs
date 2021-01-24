    Stopwatch sw = new Stopwatch();
    
    var arg = new Out<int>();
    sw.Start();
    var task = DoWorkAsync(arg);
    await task;
    sw.Stop();
    
    Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds);
    
    Console.WriteLine(arg.Value); // Prints '13' in the console :-)
