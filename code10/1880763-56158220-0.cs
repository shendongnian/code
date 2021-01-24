        List<Task> bagConsumeTasks = new List<Task>();
        int itemsInBag = 0;
        for (int i = 0; i < 500; i++)
        {
            bagConsumeTasks.Add(Task.Run(() =>
            {
                int item;
                if (cb.TryTake(out item))
                {
                    Console.WriteLine(item);
                    Interlocked.Increment(ref itemsInBag);
                }
            }));
        }
        Task.WaitAll(bagConsumeTasks.ToArray());
