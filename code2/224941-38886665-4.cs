    // private field somewhere appropriate; it would probably be best to put
    // this logic into a reusable class.
    DateTime _nextRunTime;
    async Task RunPeriodically(Action action,
        DateTime startTime, TimeSpan interval, CancellationToken token)
    {
        _nextRunTime = startTime;
        while (true)
        {
            TimeSpan delay = _nextRunTime - DateTime.UtcNow;
            
            if (delay > TimeSpan.Zero)
            {                
                await Task.Delay(delay, token);
            }
            action();
            _nextRunTime += interval;
        }
    }
