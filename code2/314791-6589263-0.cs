    StopWatch sw = new StopWatch();
    sw.Start();
    Enumerable.Range(0, max)
              .AsParallel()
              .ForAll(number =>
                   Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, number));
    Console.WriteLine("{0} ms elapsed", sw.ElapsedMilliseconds);
