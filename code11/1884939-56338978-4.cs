    private readonly ViewModel viewModel = new ViewModel();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = viewModel;
        viewModel.Items.Add(new Item { ID = 1, ... });
        viewModel.Items.Add(new Item { ID = 2, ... });
    }
