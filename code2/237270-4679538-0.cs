    public MainWindow()
	{
		MainWindowViewModel viewModel = new MainWindowViewModel();
		this.DataContext = viewModel;
		InitializeComponent();
	}
