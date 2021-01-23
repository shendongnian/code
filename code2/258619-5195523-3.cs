    RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
    byte[] buffer = new byte[4];
    random.GetBytes(buffer);
    // Creates a random number of tasks (not less than 2 -- up to 9)
    int iteration = new Random(BitConverter.ToInt32(buffer, 0)).Next(2, 9);
    Console.WriteLine("Creating " + iteration + " Parallel Tasks . . .");
    Dictionary<int, string> items = new Dictionary<int, string>();
    for (int i = 1; i < iteration + 1; i++) // cosmetic +1 to avoid "Task N° 0"
    {
        items.Add(i, "Parallel Task N° " + i);
    }
    List<Task> tasks = new List<Task>();
    // I guess we should use a Parallel.Foreach() here
    foreach (var item in items)
    {
        // Creates a random interval to pause the thread at (up to 9 secs)
        random.GetBytes(buffer);
        int interval = new Random(BitConverter.ToInt32(buffer, 0)).Next(1000, 9000);
        // http://stackoverflow.com/questions/5195486/
        var temp = item;
        var task = Task.Factory.StartNew(state =>
        {
            Console.WriteLine(String.Format(temp.Value + " will be completed in {0} miliseconds . . .", interval));
            Thread.Sleep(interval);
            return "The quick brown fox jumps over the lazy dog.";
        }, temp.Value).ContinueWith(t => Console.WriteLine(t.AsyncState + " returned: " + t.Result));
        tasks.Add(task);
    }
    Task.WaitAll(tasks.ToArray());
