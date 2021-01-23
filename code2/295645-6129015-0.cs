    var root = new Task<int>(() => 0);
    var end = root;
    for(int i = 0 ; i < 1000000 ; i++)
    {
        end = end.ContinueWith(last => last.Result + 1);
    }
    var watch = Stopwatch.StartNew();
    root.Start();
    end.Wait();
    watch.Stop();
    Console.WriteLine("{0} in {1}ms", end.Result, watch.ElapsedMilliseconds);
