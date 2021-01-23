    var subject = new Subject<Unit>();
    subject
        .AsObservable()
        .Materialize()
        .Take(1)
        .Where(n => n.Kind == NotificationKind.OnCompleted)
        .Subscribe(_ => Assert.Fail());
    
    subject.OnNext(new Unit());
    subject.OnCompleted();
