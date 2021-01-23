    var ce = new CountdownEvent( 1 );
    foreach ( var item in _queueAccess )
    {
        ce.AddCount();
        var capturedItem = item;
        Task.Factory.StartNew( () => { RunJob( capturedItem ); ce.Signal(); } );
    }
    ce.Signal();
    ce.Wait();
