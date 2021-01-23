    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            Loaded += (s, e) =>
                {
                    var myCustomer1 = new Customer();
                    var myCustomer2 = new Customer();
                    
                    var customers = new ObservableCollection<Customer>();
                    customers.Add(myCustomer1);
                    customers.Add(myCustomer2);
                    CustomersList.ItemsSource = customers;
                };
        }
    }
