    private readonly DispatcherTimer timer = new DispatcherTimer();
    public Window1()
    {
        timer.Interval = TimeSpan.FromMilliseconds(1000);
        timer.Tick += new EventHandler(timer_Tick);
    }
    private void btnStart_Click(object sender, RoutedEventArgs e)
    {
        if (!timer.IsEnabled)
        {
            timer.Start();
        }
    }
    private void btnStop_Click(object sender, RoutedEventArgs e)
    {
        timer.Stop();
    }
    private void timer_Tick(object sender, EventArgs e)
    {
        //data insert
    }
