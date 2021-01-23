    private Timer _timer;
    private Boolean _overflow;
    private void QueueNextTime(DateTime thisTime)
    {
        TimeSpan interval = this.GetNextRunTime(thisTime) - DateTime.Now;
        Int64 intervalInt = (Int64)((interval.TotalMilliseconds <= 0) ? 1 : interval.TotalMilliseconds);
        // If interval greater than Int32.MaxValue, set the boolean to skip the next run. The interval will be topped at Int32.MaxValue.
        // The TimerElapsed function will call this function again anyway, so no need to store any information on how much is left.
        // It'll just repeat until the overflow status is 'false'.
        this._overflow = intervalInt > Int32.MaxValue;
        this._timer.Interval = Math.Min(intervalInt, Int32.MaxValue);
        this._timer.Start();
    }
    
    // The function linked to _timer.Elapsed
    private void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        this._timer.Stop();
        if (this._overflow)
        {
            QueueNextTime(e.SignalTime);
            return;
        }
        // Execute tasks
        // ...
        // ...
        // schedule next execution
        QueueNextTime(e.SignalTime);
    }
