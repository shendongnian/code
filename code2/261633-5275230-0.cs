    private List<Customer> _customerList = new List<Customer>();
    
    protected void DoWork(object sender, DoWorkEventArgs e)
    {
        MyDataGridView.DataSource = _customerList;  // Here is where you'll set your data source and bindings
        Load_Customer_Method();
    }
    
    private void Load_Customer_Method()
    {
        int totalCustomers = 20;
        int currentCustomer = 1;
    
        for(currentCustomer = 1; currentCustomer <= totalCustomers; currentCustomer++)
        {
            Customer c = new Customer();
            // Configure customer
    
            ReportProgress(100*currentCustomer/totalCustomers, c);
        }
    }
    
    private void ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        Customer addedCustomer = (Customer)e.UserState;
        _customerList.Add(addedCustomer);  // If bindings are set, this update is automatic
        MyDataGridView.Refresh();  // Force a refresh of the screen for this grid to make
                                   // it appear as if the grid is populating one object at
                                   // a time. 
    }
