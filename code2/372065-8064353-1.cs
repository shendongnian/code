    var data = new byte[4096];
    var random = new Random();      
    var queue = new Queue<byte>();
    var stopWatch = new Stopwatch();
    TimeSpan dequeueTimespan, tryDequeueTimespan;
    stopWatch.Restart();
    for (int i = 0; i < 1000000; i++)
    {
        random.NextBytes(data);
        foreach (var item in data)
        {
            queue.Enqueue(item);
        }
        Dequeue(queue, 1024);
        queue.Clear();
    }
    stopWatch.Stop();
    dequeueTimespan = stopWatch.Elapsed;
    stopWatch.Restart();
    for (int i = 0; i < 1000000; i++)
    {
        random.NextBytes(data);
        foreach (var item in data)
        {
            queue.Enqueue(item);
        }
        TryDequeue(queue, 1024);
        queue.Clear();
    }
    stopWatch.Stop();
    tryDequeueTimespan = stopWatch.Elapsed;
    Console.WriteLine("Dequeue:    {0}", dequeueTimespan);
    Console.WriteLine("TryDequeue: {0}", tryDequeueTimespan);
    Console.ReadKey();
