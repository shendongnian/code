    interface ICustomerView
    {
        event EventHandler EditCustomerDetails;
    
        void Show(Customer customer);
    }
    
    class CustomerView : ICustomerView
    {
        Customer customer;
        readonly Form form;	
        readonly Button editCustomerDetailsButton;        
    
        public event EventHandler EditCustomerDetails;
    
        public CustomerView()
        {
            // UI initialization.
    
            this.editCustomerDetailsButton.Click += delegate
            {
                var Handler = this.EditCustomerDetails;
    
                if (Handler != null)
                {
                    Handler(this, EventArgs.Empty);
                }
            };
        }
    
        public void Show(Customer customer)
        {
            if (this.form.Visible)
            {
                // Update UI with new data.
            }
            else
            {
                // Initialize UI with data and then show it.
                this.form.ShowDialog();
            }
        }
    }
    
    interface ICustomerPresenter
    {
        void ShowView(ICustomer customer);
    }
    
    class CustomerPresenter : ICustomerPresenter
    {        
        readonly ICustomerView view;
        readonly IEditCustomerPresenter editPresenter;
        ICustomer customer;
    
        public ConfigurationPresenter(ICustomerView view, IEditCustomerPresenter editPresenter)
        {
            this.view = view;            
            this.view.EditCustomerDetails += delegate
            {
                this.editPresenter.ShowView(this.customer); // Edit
                this.view.Show(this.customer);              // Update
            };
            this.editPresenter = editPresenter;
        }
        public void ShowView(ICustomer customer)
        {
            this.customer = customer;
            this.view.Show(customer); // Assuming modal
            this.customer = null;
        }
    }
