    DataGridView customerView;    
    DataGridView supplierView;    // initialize in form
    
    DataTable companiesTable;    // initialized and filled
    
    void SetCustomerCompanyView()
    {
        DataView cust = new DataView();
        
        cust.Table = companiesTable;
        cust.RowFilter = "Type = 'Customer'"; 
    
        customerView.DataSource = cust;
    }
    
    //  repeat for SetSupplierCompanyView()  
