    public MainWindow()
    {
        InitializeComponent();
        var vm = new ViewModel();
        for (int i = 0; i < 100; i++)
        {
            vm.Cells.Add(new Cell { State = i % 3 == 0 ? CellState.Dead : CellState.Active });
        }
        DataContext = vm;
    }
