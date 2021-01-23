    System.IO.Path.GetRandomFileName();
    Stopwatch watch = Stopwatch.StartNew();
    string[] x = new string[500];
    for (int i = 0; i < 500; i++)
    {
        x[i] = System.IO.Path.GetRandomFileName();
    }
    watch.Stop();
    Console.WriteLine(watch.ElapsedMilliseconds);
