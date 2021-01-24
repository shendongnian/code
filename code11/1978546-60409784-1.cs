    using var cts = new CancellationTokenSource( 100 );
    var longWaitingTask = Task.Delay( 250 );
    var cancellationTask = Async.CompleteOnCancellation( cts.Token );
    var completedTask = await Task.WhenAny( longWaitingTask, cancellationTask );
    if ( completedTask == longWaitingTask )
    {
        Console.WriteLine( "Long Running Task completed." );
    }
    if ( completedTask == cancellationTask )
    {
        Console.WriteLine( "Cancellation Task completed." );
    }
