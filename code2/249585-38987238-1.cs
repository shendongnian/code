    var lockObject = "";
    var tasks = new List<Task>();
    for (var i = 0; i < 10; i++)
        tasks.Add(Task.Run(() =>
        {
            Thread.Sleep(250);
            lock (lockObject)
            {
                lockObject += "x";
            }
        }));
    Task.WaitAll(tasks.ToArray());
