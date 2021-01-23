    using (var context = new MyDbContext())
    {
        Random rand = new Random();
        var ids = new List<int>();
        for (int i = 0; i < 20000; i++)
            ids.Add(rand.Next(550000));
        Stopwatch watch = new Stopwatch();
        watch.Start();
        // here are the code snippets from below
        watch.Stop();
        var msec = watch.ElapsedMilliseconds;
    }
