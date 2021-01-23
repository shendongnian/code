    public Form1()
    {
        InitializeComponent();
        ci.CustomerName = "TestCustomerName";
        customerInfoBindingSource.DataSource = ci;
    }
