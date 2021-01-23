    public Form1()
    {
        InitializeComponent();
        customerInfoBindingSource.DataSource = ci;  // This is the missing line
    }
