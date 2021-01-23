    public partial class Window1 : Window
    {
        private MyDataSetModel _myDataModel;
        public Window1()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Window1_Loaded);
        }
        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            _myDataModel = new MyDataSetModel();
            _myDataModel.FetchCustomers();
            listView1.ItemsSource = _myDataModel.Customers;
        }
    }
