    BackgroundWorker bgWorker = new BackgroundWorker();
    ObservableCollection<int> mNumbers = new ObservableCollection<int>();
    
    public Window1()
    {
        InitializeComponent();
        bgWorker.DoWork += 
            new DoWorkEventHandler(bgWorker_DoWork);
        bgWorker.ProgressChanged += 
            new ProgressChangedEventHandler(bgWorker_ProgressChanged);
        bgWorker.RunWorkerCompleted += 
            new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);
        bgWorker.WorkerReportsProgress = true;
    
        btnGenerateNumbers.Click += (s, e) => UpdateNumbers();
    
        this.DataContext = this;
    }
    
    void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        progress.Visibility = Visibility.Collapsed;
        lstItems.Opacity = 1d;
        btnGenerateNumbers.IsEnabled = true;
    }
    
    void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        List<int> numbers = (List<int>)e.UserState;
        foreach (int number in numbers)
        {
             mNumbers.Add(number);
        }
    
        progress.Value = e.ProgressPercentage;
    }
    
    void bgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        Random rnd = new Random();
        List<int> numbers = new List<int>(10);
    
        for (int i = 1; i <= 100; i++)
        {
            // Add a random number
            numbers.Add(rnd.Next());            
    
            // Sleep from 1/8 of a second to 1 second
            Thread.Sleep(rnd.Next(125, 1000));
    
            // Every 10 iterations, report progress
            if ((i % 10) == 0)
            {
                bgWorker.ReportProgress(i, numbers.ToList<int>());
                numbers.Clear();
            }
        }
    }
    
    public ObservableCollection<int> NumberItems
    {
        get { return mNumbers; }
    }
    
    private void UpdateNumbers()
    {
        btnGenerateNumbers.IsEnabled = false;
        mNumbers.Clear();
        progress.Value = 0;
        progress.Visibility = Visibility.Visible;
        lstItems.Opacity = 0.5;
    
        bgWorker.RunWorkerAsync();
    }
