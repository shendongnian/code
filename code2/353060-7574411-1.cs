    var list = new List<int> { 1, 2, 3 };
    var obs = list.ToObservable();
    var subscription = obs.SubscribeOn(Scheduler.NewThread).Subscribe(p =>
        {
            Console.WriteLine(p.ToString());
            Thread.Sleep(200);
        },
        error => Console.WriteLine("Error!"),
        () => Console.WriteLine("sequence completed"));
    Console.ReadLine();
    subscription.Dispose();
