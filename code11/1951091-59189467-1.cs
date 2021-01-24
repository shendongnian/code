    public MainWindow()
    {
        InitializeComponent();
        var vm = new MyViewModel();
        vm.MyCollection.Add("A");
        vm.MyCollection.Add("B");
        vm.MyCollection.Add("C");
        vm.MyCollection.Add("D");
        vm.MySelection = "C";
        DataContext = vm;
    }
    private void OnClickButton(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(((MyViewModel)DataContext).MySelection);
    }
