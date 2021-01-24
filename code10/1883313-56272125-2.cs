    var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
    timer.Tick += async (s, e) =>
    {
        if (Process.GetProcessesByName(processName).Length > 0)
        {
            await Task.Run(() =>
            {
                // lengthy operation here
            });
            // udate UI here
        }
    };
    timer.Start();
