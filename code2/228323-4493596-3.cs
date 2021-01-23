    private BackgroundWorker m_changeColorBgWorker = null;
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        m_changeColorBgWorker = new BackgroundWorker();
        m_changeColorBgWorker.DoWork += new DoWorkEventHandler(m_changeColorBgWorker_DoWork);
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        if (m_changeColorBgWorker.IsBusy == false)
        {
            m_changeColorBgWorker.RunWorkerAsync();
        }
    }
    void m_changeColorBgWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        while (true)
        {
            for (int c = 0; c < 254; c++)
            {
                MyColorProperty = Color.FromArgb(255, (byte)c, (byte)(255 - c), (byte)c);
                Thread.Sleep(10); 
            }
        }
    }
