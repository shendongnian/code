    public MyView()
    {
    	InitializeComponent();
    	LoadItems();
    	DataContext = this;
    }
    
    public IEnumerable<Payee> Payees { get; set; }
    
    private void LoadItems()
    {
    	Payees = PayeeManager.GetPayees();
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
    	cbPayee.SelectedValue = new Payee(2, "Steve").ID;
    }
