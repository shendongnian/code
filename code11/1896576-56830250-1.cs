    public Splash()
    {
        InitializeComponent();
        this.DataContext = this;
    
        this.changeLoadingTxtTimer = new System.Timers.Timer(2000);
        this.changeLoadingTxtTimer.Elapsed += Timer_Elapsed;
        this.changeLoadingTxtTimer.Start();
    }
    
    public void CloseSplashScreen()
    {
        this.changeLoadingTxtTimer.Stop();
        this.changeLoadingTxtTimer.Dispose();
        Close();
    }
    
    private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        this.Dispatcher.Invoke(() => this.LoadingTxtValue = this.LoadingTxts[rd.Next(0, this.LoadingTxts.Length - 1)]);
    }
