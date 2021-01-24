    var source = new TaskCompletionSource<(object, EventArgs)>();  //Change the EventArgs type to the actual event args type that the event passes.
    EVENT_YOU_WISH_TO_WAIT_FOR += (s, e) => source.TrySetResult((s, e));
    
    async void timeout()
    {
        await Task.Delay(10000);  //10 secs
        source.TrySetException(new TaskCanceledException());
    }
    timeout();
    
    try
    {
        var (sender, @event) = await source.Task;
        //Statements here would be executed on the event is raised.
        //Do things with sender and @event provided.
    }
    catch (TaskCanceledException)
    {
        //Handle timeout.
    }
