    private Customer Customer { get ; set; }
    public void Initialize(Customer cust) {
        this.Customer = cust;
    }
    
    
    var f = new CustomerForm();
    f.Initialize(_myCustomer);
    f.ShowDialog();
