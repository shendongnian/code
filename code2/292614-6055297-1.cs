    CompositeDisposable subsriptions = new CompositeDisposable();
    subscriptions.Add(Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe());
    subscriptions.Add(Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe());
    subscriptions.Add(Observable.Interval(TimeSpan.FromSeconds(1)).Subscribe());
    subscriptions.Dispose();
