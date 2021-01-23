    DispatcherTimer timer = new DispatcherTimer();
    DateTime endDate = new DateTime();
    TimeSpan timeToGo = new TimeSpan(0, 1, 0);
    public MainWindow()
    {
        InitializeComponent();
        this.timer.Tick += new EventHandler(timer_Tick);
        this.timer.Interval = new TimeSpan(0, 0, 1);
        this.endDate = DateTime.Now.Add(timeToGo);
        this.timer.Start();
    }
    void timer_Tick(object sender, EventArgs e)
    {
        this.lblTimer.Content = this.ToStringTimeSpan(this.endDate - DateTime.Now);
        if (this.endDate == DateTime.Now)
        {
            this.timer.Stop();
        }
    }
    string ToStringTimeSpan(TimeSpan time)
    {
        return String.Format("{0:d2}:{1:d2}:{2:d2}", time.Hours, time.Minutes, time.Seconds);
    }
