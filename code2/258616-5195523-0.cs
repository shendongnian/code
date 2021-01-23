    foreach (var item in items)
    {
        random.GetBytes(buffer);
        int interval = new Random(BitConverter.ToInt32(buffer, 0)).Next(1000, 9000);
        var task = Task.Factory.StartNew(state =>
        {
            Console.WriteLine(String.Format(item.Value + " will be completed in {0} miliseconds . . .", interval));
            Thread.Sleep(interval);
            return "The quick brown fox jumps over the lazy dog.";
        }, item.Value);
        tasks.Add(task);
    }
    foreach (var task in tasks)
    {
        Console.WriteLine(task.AsyncState + " returned: " + task.Result);
    } 
