    DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
    //Constructor
    public MyMessageBox()
    {
        timer.Interval = TimeSpan.FromSeconds(20d);
        timer.Tick += new EventHandler(timer_Tick);
    }
    public new void Show()
    {
        base.Show();
        timer.Start();
    }
    void timer_Tick(object sender, EventArgs e)
    {
        //set default result if necessary
        timer.Stop();
        this.Close();
    }
