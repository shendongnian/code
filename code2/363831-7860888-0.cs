    private void MyFunction()
    {
        DispatcherTimer timer = new DispatcherTimer();
        timer.Interval = new TimeSpan(0, 0, 1);
        EventHandler eh = null;
        eh = (object sender, object e) =>
        {
            timer.Tick -= eh;
            timer.Stop();
            // Some code here
        };
        timer.Tick += eh;
        timer.Start();
    }
