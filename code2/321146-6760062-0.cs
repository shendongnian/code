    var pulses = Observable.GenerateWithTime(0,
        i => true, i => i + 1, i => i,
        i => TimeSpan.FromMilliseconds(500));
    // Get your CancellationTokenSource
    CancellationTokenSource ts = ...
    // Subscribe
    ts.Token.Register(pulses.Subscribe(...).Dispose);
