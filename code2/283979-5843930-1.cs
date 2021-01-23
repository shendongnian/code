    Queue = new BlockingCollection<Tuple<IDevice, Data>>(
        new DeviceDataQueue<IDevice, Data>());
    Device1 = new Device(1, TimeSpan.FromSeconds(3), Queue);
    Device2 = new Device(2, TimeSpan.FromSeconds(5), Queue);
    while (true)
    {
        var tuple = Queue.Take();
        var device = tuple.Item1;
        var data = tuple.Item2;
        Console.WriteLine("{0}: Device {1} produced data at {2}.",
            DateTime.Now, device.Id, data.Created);
        Thread.Sleep(TimeSpan.FromSeconds(2));
    }
