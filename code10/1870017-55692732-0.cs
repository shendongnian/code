    public Task MyWhenAll(Task t1, Task t2)
    {
        return Task.Delay(TimeSpan.FromMilliseconds(100))
            .ContinueWith(_ => Task.WhenAll(t1, t2))
            .Unwrap();
    }
