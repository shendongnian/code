    private bool m_onStart = true;
    public MainWindow()
    {
            InitializeComponent();
            this.LayoutUpdated += new EventHandler(MainWindow_LayoutUpdated);
    }
    void MainWindow_LayoutUpdated(object sender, EventArgs e)
    {
         if (m_onStart)
         {
             m_onStart = false;
             Dispatcher.BeginInvoke(() =>
             {
                  //Start App
             }
             );
         }
     }
