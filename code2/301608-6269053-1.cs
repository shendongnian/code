    private DispatcherTimer timer;
    timer = new DispatcherTimer();
                timer.Tick += new EventHandler(timer_Tick);
                timer.Interval = TimeSpan.FromMilliseconds(5000);
                timer.IsEnabled = true;
    void timer_Tick(object sender, EventArgs e)
            {
    ///Close your window here
    }
