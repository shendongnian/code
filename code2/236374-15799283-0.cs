    var work = new ConcurrentQueue<Item>();
    var producer1 = Task.Factory.StartNew(() => {
        work.Enqueue(item); // or whatever your threads are doing
    });
    var producer2 = Task.Factory.StartNew(() => {
        work.Enqueue(item); // etc
    });
    var consumer = Task.Factory.StartNew(() => {
        while(running) {
            Item item = null;
            work.TryDequeue(out item);
        }
    });
    Task.WaitAll(producer1, producer2, consumer);
