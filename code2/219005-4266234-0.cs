    public partial class Window1 : Window
    {
        private DispatcherFrame frame;
        private readonly ObservableCollection<string> collection = new ObservableCollection<string>();
        public Window1()
        {
            InitializeComponent();
            DataContext = collection;
        }
        private void GetData(object sender, RoutedEventArgs e)
        {
            collection.Clear();
            frame = new DispatcherFrame();
            popupGrid.Visibility = Visibility.Visible;
            System.Windows.Threading.Dispatcher.PushFrame(frame); // blocks gui message pump & creates nested pump
            var count = int.Parse(countText.Text); // after DispatcherFrame is cancelled, it continues
            for (int i = 0; i < count; i++)
                collection.Add("Test Data " + i);
            popupGrid.Visibility = Visibility.Hidden;
        }
        private void DataCountEntered(object sender, RoutedEventArgs e)
        {
            frame.Continue = false; // un-blocks gui message pump
        }
    }
