    public sealed partial class MainPage : Page
    {
        Data Data { get; set; } = Whatever;
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            cb.SelectedIndex = 0;
        }
    }
