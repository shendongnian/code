    private readonly object _syncObj = new object();
    [Test]
    public object measure_queue_locking_performance()
    {
        const int TestIterations = 5;
        const int Iterations = (10 * 1000 * 1000);
        Action<string, Action> time = (name, test) =>
        {
            for (int i = 0; i < TestIterations; i++)
            {
                TimeSpan elapsed = TimeTest(test, Iterations);
                Console.WriteLine("{0}:{1:F2}ms", name, elapsed.TotalMilliseconds);
            }
        };
        object itemOut, itemIn = new object();
        Queue queue = new Queue();
        Queue syncQueue = Queue.Synchronized(queue);
        Action test1 = () =>
        {
            lock (_syncObj) queue.Enqueue(itemIn);
            lock (_syncObj) itemOut = queue.Dequeue();
        };
        Action test2 = () =>
        {
            syncQueue.Enqueue(itemIn);
            itemOut = syncQueue.Dequeue();
        };
        Console.WriteLine("Iterations:{0:0,0}\r\n", Iterations);
        time("Queue+Lock", test1);
        time("SynchonizedQueue", test2);
        return itemOut;
    }
    [SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.GC.Collect")]
    private static TimeSpan TimeTest(Action action, int iterations)
    {
        Action gc = () =>
        {
            GC.Collect();
            GC.WaitForFullGCComplete();
        };
        Action empty = () => { };
        Stopwatch stopwatch1 = Stopwatch.StartNew();
        for (int j = 0; j < iterations; j++)
        {
            empty();
        }
        TimeSpan loopElapsed = stopwatch1.Elapsed;
        gc();
        action(); //JIT
        action(); //Optimize
        Stopwatch stopwatch2 = Stopwatch.StartNew();
        for (int j = 0; j < iterations; j++) action();
        gc();
        TimeSpan testElapsed = stopwatch2.Elapsed;
        return (testElapsed - loopElapsed);
    }
