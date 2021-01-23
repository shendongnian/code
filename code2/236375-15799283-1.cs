    var work = new BlockingCollection<Item>();
    var producer1 = Task.Factory.StartNew(() => {
        work.TryAdd(item); // or whatever your threads are doing
    });
    var producer2 = Task.Factory.StartNew(() => {
        work.TryAdd(item); // etc
    });
    var consumer = Task.Factory.StartNew(() => {
        foreach (var item in work.GetConsumingEnumerable()) {
            // do the work
        }
    });
    Task.WaitAll(producer1, producer2, consumer);
