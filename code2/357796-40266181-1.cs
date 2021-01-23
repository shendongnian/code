    IObservable<string> source = ...;
    var subscription = new SingleAssignmentDisposable();
    subscription.Disposable = source.Subscribe(x =>
    {
        if (subscription.IsDisposed) // getting notified though I've told it to stop
            return;
        DoThingsWithItem(x);
        if (x == "the last item I'm interested in")
            subscription.Dispose();
    });
