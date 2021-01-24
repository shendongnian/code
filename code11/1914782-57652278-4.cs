    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        DataContext = vm;
        vm.SomeList.Add(new DummyModel1 { Name = "?", ID = 1 });
        vm.SomeList.Add(new DummyModel2 { Name = "?", ID = 2, ... });
    }
