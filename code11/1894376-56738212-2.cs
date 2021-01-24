    using (var tokenSource = new CancellationTokenSource())
    {
        IEnumerable<IAgent> agents; // TODO: initialize
    
        var tasks = new List<Task>();
        foreach (var agent in agents)
        {
            var task = agent.RunAsync(tokenSource.Token)
                .ContinueWith(t =>
                {
                    if (t.IsCanceled)
                    {
                        // Do something if cancelled.
                    }
                    else if (t.IsFaulted)
                    {
                        // Do something if faulted (with t.Exception)
                    }
                    else
                    {
                        // Do something if the task has completed.
                    }
                });
    
            tasks.Add(task);
        }
    
        await Task.WhenAll(tasks);
    }
