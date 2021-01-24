        _Timer = new System.Timers.Timer(TimeSpan.FromMinutes(5).TotalMilliseconds)
        {
            Enabled = true
        };
        // add this
        ExecuteEvery5Min();
        _Timer.Elapsed += (sender, eventArgs) =>
        {
            ExecuteEvery5Min();
        };
