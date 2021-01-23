    public class MainWindowViewModel : WorkspaceViewModel
    {
        readonly CustomerRepository _customerRepository;
        public MainWindowViewModel(...)
        {
            _customerRepository = new CustomerRepository(customerDataFile);
        }
        void _createNewCustomer()
        {
            var newCustomer = Customer.CreateNewCustomer();
            var workspace = new CustomerViewModel(newCustomer, _customerRepository);
            Workspaces.Add(workspace);
            _setActiveWorkspace(workspace);
        }
        ObservableCollection<WorkspaceViewModel> _workspaces;
        void _setActiveWorkspace(WorkspaceViewModel workspace)
        {
            var collectionView = CollectionViewSource.GetDefaultView(Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
     }
