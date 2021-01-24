    public MainWindow()
	{
		InitializeComponent();
		var ucs = new List<UserControl1>();
		ucs.Add(new UserControl1());
		ucs.Add(new UserControl1());
		ucs.Add(new UserControl1());
		ic.ItemsSource = ucs;
	}
