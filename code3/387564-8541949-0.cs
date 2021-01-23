    var x = Observable.Create<T>(subj => { /* Fill it in*/ })
        .Multicast(new Subject<T>());
    // Set up your subscriptions Here!
    // When you call the Connect, whatever is in the Observable.Create will be called
    x.Connect();
