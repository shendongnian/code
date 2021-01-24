    public MainWindow()
    {
        InitializeComponent();
        this.IsEnabled = false;
    }
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        MessageBoxResult result = MessageBox.Show("asd", "xcvxcv", MessageBoxButton.OKCancel);
        if (result == MessageBoxResult.OK)
            MessageBox.Show("Ok was selected");
        this.IsEnabled = true;
    }
