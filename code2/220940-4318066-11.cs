    public class CustomerManagementPresenter
    {
        private ICustomer _selectedCustomer;
        private readonly ICustomerManagementView _managementView;
        private readonly ICustomerRepository _customerRepository;
        public CustomerManagementPresenter(ICustomerManagementView managementView, ICustomerRepository customerRepository)
        {
            _managementView = managementView;
            _managementView.SelectedCustomerChanged += this.SelectedCustomerChanged;
            _customerRepository = customerRepository;
            _managementView.InitializeCustomers(_customerRepository.FetchCustomers());
        }
        private void SelectedCustomerChanged(object sender, EventArgs<ICustomer> args)
        {
            // Perform some logic here to update the view
            if(_selectedCustomer != args.Value)
            {
                _selectedCustomer = args.Value;
                _view.DisplayCustomer(_selectedCustomer);
            }
        }
    }
