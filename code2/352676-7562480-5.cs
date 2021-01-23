    WorkItem item;
    while (WorkItems.TryTake(out item, Timeout.Infinite, _cancellation))
    {
        Task.Factory.StartNew((s) =>
            {
                var myItem = (WorkItem)s;
                // process here
            }, item);
    }
