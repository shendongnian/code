    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
    
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CustomerHeaderViewModel customerHeaderViewModel = new CustomerHeaderViewModel();
            customerHeaderViewModel.LoadCustomers();
            CustomerHeaderView.DataContext = customerHeaderViewModel;
        }
    }
