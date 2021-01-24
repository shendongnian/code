    public MainWindow()
    {
        InitializeComponent();
        TheTasks = new ObservableCollection<CheckBoxContentNotifier>();
        DataContext = this;
    }
