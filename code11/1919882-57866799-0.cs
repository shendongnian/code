    MainWindowViewModel mwvm = new MainWindowViewModel();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = mwvm;
    }
    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        mwvm.insertIntoDb();            
    }
