    public partial class Window1 : Window
    {
        private MyDataSetViewModel _mdsvm;
        public Window1()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Window1_Loaded);
        }
    
        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            _mdsvm = new MyDataSetViewModel();
            _mdsvm.FetchCustomers();
    
            listView1.ItemsSource = _mdsvm.Customers;
        }
    }
