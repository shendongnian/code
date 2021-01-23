    public MainWindow()
    {
        InitializeComponent();
        //start a new thread to obtain CPU usage
        PerformanceClass pc = new PerformanceClass();
        pc.DataUpdate += HandleDataUpdate;
        Thread pcThread = new Thread(pc.CPUThread); 
        pcThread.Start();
    }
    
    private void HandleDataUpdate(object sender, PerformanceEventArgs e)
    {
         // dispatch the modification to the text box to the UI thread (main window dispatcher)
         Dispatcher.BeginInvoke(DispatcherPriority.Normal, () => { txt_CPU.Text = e.Data });
    }
 
