    public MainWindow()
    {
        InitializeComponent();
        PropertyChanged += MainWindow_PropertyChanged;
        DataContext = this;
    }
    private void MainWindow_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(LogDataSet))
        {
            for (int i = 0; i < DgLogs.Columns.Count; i++)
            {
                DgLogs.Columns[i].Visibility = LogDataSet.DisplayColumns[i] ? Visibility.Visible : Visibility.Collapsed;
            }
        }
    }
