    var s1 = new Subject<Unit>();
    var s2 = new Subject<Unit>();
    var ss = Observable.Amb(
            s1.Materialize().Where(x => x.Kind == NotificationKind.OnCompleted), 
            s2.Materialize().Where(x => x.Kind == NotificationKind.OnCompleted)
        )
        .Finally(() => Console.WriteLine("Finished!"));
    ss.Subscribe(_ => Console.WriteLine("Next"));
    s1.OnNext(new Unit());
    s2.OnNext(new Unit());
    s1.OnCompleted(); // ss will finish here and s2 will be unsubscribed from
    
