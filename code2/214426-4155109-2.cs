    CustomerViewModel
    {
        string Id { get; private set; }
        string Name { get; set; }
        public static readonly CustomerViewModel All { get; private set; }
        
        static CustomerViewModel()
        {
           // set up the one and only "All" item
           All = new CustomerViewModel();
           All.Name = ResourceStrings.All;
        }
    
    
        private CustomerViewModel()
        {
        }
    
        public CustomerViewModel(Customer actualCustomer)
        {
            this.Name = actualCustomer.Name;
            this.Id = actualCustomer.Id;
        }
    }
    someOtherViewModel.Customers = new ObservableCollection<CustomerViewModel>();
    // add all the wrapping CustomerViewModel instances to the collection
    someOtherViewModel.Customers.Add(CustomerViewModel.All);
