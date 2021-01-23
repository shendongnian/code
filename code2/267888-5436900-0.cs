    namespace WpfApplication1.ViewModel
    {
        class MyDataSetViewModel
        {
            private DataSet1 _myDataSet;
            private DataSet1TableAdapters.CustomerTableAdapter _myCustomerTableAdapter;
            public DataSet1.CustomerDataTable Customers
            {
                get { return _myDataSet.Customer; }   
            }
    
            public void FetchCustomers()
            {
                _myDataSet = new DataSet1();
                _myCustomerTableAdapter = new CustomerTableAdapter();
                _myCustomerTableAdapter.Fill(_myDataSet.Customer);
            }
        }
    }
