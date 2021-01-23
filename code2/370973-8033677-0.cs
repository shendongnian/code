    BackgroundWorker bgw;
    Stopwatch watch;
    public Form1()
    {
      InitializeComponent();
      label1.Text = "";
      watch = new Stopwatch();
      bgw = new BackgroundWorker();
      bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
      bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
      bgw.WorkerReportsProgress = true;
      bgw.WorkerSupportsCancellation = true;
    }
    
    private void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
      while (true)
      {
        bgw.ReportProgress(0);
        System.Threading.Thread.Sleep(100);
        
        if (!watch.IsRunning)
          break;
      }
    }
    private void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      TimeSpan ts = watch.Elapsed;
      label1.Text = String.Format("{0:00}:{1:00}:{2:00}", ts.Minutes, ts.Seconds, ts.Milliseconds);
    }
    private void button1_Click(object sender, EventArgs e)
    {
      watch.Start();
      bgw.RunWorkerAsync();
    }
    private void button2_Click(object sender, EventArgs e)
    {
      watch.Stop();
      watch.Reset();
      bgw.CancelAsync();      
    }
