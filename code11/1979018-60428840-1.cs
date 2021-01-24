    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            sp.Tag = Visibility.Collapsed;
            var obj = await getSomeObjectAsync();
            // obj would be some dto or something in a real app and you'd do something with it
            sp.Tag = Visibility.Visible;
        }
        private static async Task<object> getSomeObjectAsync()
        {
            // You would do something like database access here rather than just delay.
            await Task.Delay(2000);
            return new object();
        }
    }
