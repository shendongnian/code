    var stopWatch = new Stopwatch();
    stopWatch.Start();
    for (int i = 0; i < 1_000_000; i++) {
        photo.Height = 4;
        double price = photo.Price;
        photo.Height = 10;
        price = photo.Price;
    }
    stopWatch.Stop();
    Console.WriteLine("Elapsed ms: " + stopWatch.ElapsedMilliseconds);
