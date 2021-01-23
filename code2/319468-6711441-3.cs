    SystemTimer = new Timer();
    SystemTimer.Interval = CycleInterval;
    SystemTimer.Enabled = true;
    SystemTimer.Elapsed += Cycle;
    SystemTimer.Start();
