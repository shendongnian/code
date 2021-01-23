    private DateTime startTime;
    public Timer()
    {
        InitializeComponent();
        startTime = DateTime.Now;
    }
    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        Counter = (DateTime.Now - startTime).ToString();
        ...
    }
