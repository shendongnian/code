    static Semaphore _sem = new Semaphore(3, 3);    // Capacity of 3
    static List<string> _records = new List<string>(new string[] { "aaa", "bbb", "ccc", "ddd", "eee", "fff", "ggg", "hhh" });
    static void Main()
    {
        var finishEvents = new List<EventWaitHandle>();
        for (int i = 0; i < _records.Count; i++)
        {
            var signal = new EventWaitHandle(false, EventResetMode.ManualReset);
            finishEvents.Add(signal);
            var id = _records[i];
            var t = new Thread(() =>
            {
                ThreadJob(id);
                signal.Set();
            });
            t.Start();
        }
        WaitHandle.WaitAll(finishEvents.ToArray());
        Console.WriteLine(_records.Count);
        Console.ReadLine();
    }
    static void ThreadJob(object id)
    {
        Console.WriteLine(id + " wants to enter");
        _sem.WaitOne();
        Console.WriteLine(id + " is in!");
        Thread.Sleep(1000);
        Console.WriteLine(id + " is leaving");
        lock (_records)
        {
            _records.Remove((string)id);
        }
        _sem.Release();
    }
