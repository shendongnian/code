    Stopwatch sw = new Stopwatch();
    
    var arg = new Out<int>();
    sw.Start();
    var task = Task.Run(() => DoWorkAsync(arg));
    sw.Stop();
    
    Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds + "ms");
    
    Console.WriteLine(arg.Value); // Prints '0' in the console :-(
