    var joinBlock = new SynchronizedJoinBlock<(int, int), (int, int)>(
        (x, y) => Comparer<int>.Default.Compare(x.Item1, y.Item1));
    var source1 = new (int, int)[] {(17, 1700), (18, 1800), (19, 1900),
        (20, 2000), (21, 2100), (22, 2200), (25, 2500), (26, 2600),
        (27, 2700), (28, 2800), (29, 2900)};
    var source2 = new (int, int)[] {(15, 1500), (16, 1600), (17, 1700),
        (18, 1800), (19, 1900), (20, 2000), (21, 2100), (24, 2400),
        (25, 2500), (26, 2600)};
    Array.ForEach(source1, x => joinBlock.Target1.Post(x));
    Array.ForEach(source2, x => joinBlock.Target2.Post(x));
    joinBlock.Target1.Complete();
    joinBlock.Target2.Complete();
    while (joinBlock.OutputAvailableAsync().Result)
    {
        Console.WriteLine($"> Received: {joinBlock.Receive()}");
    }
