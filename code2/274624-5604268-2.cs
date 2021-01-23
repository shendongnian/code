    var observable = Observable.Interval(TimeSpan.FromSeconds(2)); // Interval in seconds
    
    var subscription = observable.Subscribe(_ => getNews());
    // Or if it does not work then try this:
    var subscription = observable.ObserveOnWindowsForms().Subscribe(_ => getNews());
    using (subscription)
    {
        Console.WriteLine("Press any key to stop...");
        Console.ReadKey();
    }
