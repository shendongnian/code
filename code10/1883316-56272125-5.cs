    var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
    timer.Tick += (s, e) =>
    {
        if (Process.GetProcessesByName(processName).Length > 0)
        {
            // ...
        }
    };
    timer.Start();
