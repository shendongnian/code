    var sw = new Stopwatch();
    sw.Start();
    Enumerable.Range(0, max)
              .AsParallel()
              .ForAll(number =>
                   Console.WriteLine("T{0}: {1}",
                                     Thread.CurrentThread.ManagedThreadId,
                                     number));
    Console.WriteLine("{0} ms elapsed", sw.ElapsedMilliseconds);
    // Sample output from max = 10
    // 
    // T9: 3
    // T9: 4
    // T9: 5
    // T9: 6
    // T9: 7
    // T9: 8
    // T9: 9
    // T8: 1
    // T7: 2
    // T1: 0
    // 30 ms elapsed
