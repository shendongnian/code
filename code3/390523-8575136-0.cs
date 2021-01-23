    public Task StartDoingSomeStuff(CallbackDelegate callback)
    {
        var gate = new object();
        lock (gate)
        {
            Task task = null;
            task = Task.Factory.StartNew(() =>
            {
                lock (gate)
                {
                    while (whatever)
                    {
                        var results = DoSomeStuff();
                        callback(results, task);
                    }
                }
            });
            return task;
        }
    }
