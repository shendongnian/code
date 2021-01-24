    var observable2 = Observable.Create<long>(async observer =>
    {
        for (var i = 0; i <= 2; i++)
        {
            observer.OnNext(i);
            await Task.Delay(1000);
        }
        observer.OnCompleted();
        return Disposable.Empty;
    });
    
    var replaySubject2 = new ReplaySubject<long>(TimeSpan.FromMinutes(1));
    observable2.Subscribe(replaySubject2); // subscribe 
    replaySubject2.Subscribe(onNext: x => Console.WriteLine($"first:{x}"));
    replaySubject2.Subscribe(onNext: x => Console.WriteLine($"second:{x}"));
    replaySubject2.Subscribe(onNext: x => Console.WriteLine($"third:{x}"));
