    var lockObject = "";
    var tasks = new List<Task>();
    for (var i = 0; i < 10; i++)
        tasks.Add(Task.Run(() =>
        {
            Thread.Sleep(250);
            Monitor.Enter(lockObject);
            try
            {
                lockObject += "x";
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }));
    Task.WaitAll(tasks.ToArray());
