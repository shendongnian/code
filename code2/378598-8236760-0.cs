    private void Application_Startup(object sender, StartupEventArgs e)
    {
    var timer = new DispatcherTimer();
    timer.Interval = TimeSpan.FromSeconds(10);
    EventHandler eh = null;
    eh = (s, args) =>
    {
        timer.Stop();
        this.RootVisual = new Test();
        timer.Tick -= eh;
    };
    timer.Tick += eh;
    timer.Start();
    }
