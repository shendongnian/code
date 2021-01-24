    Stopwatch sw = new Stopwatch();
    
    var arg = new Out<int>();
    sw.Start();
    Task.Run(() => DoWorkAsync(arg)).Wait();
    sw.Stop();
    
    Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds);
    
    Console.WriteLine(arg.Value); // Prints '0' in the console :-(
    
