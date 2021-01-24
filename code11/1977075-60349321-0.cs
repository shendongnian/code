    public partial class MainWindow : Window
    {
        static volatile bool running = false;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (running)
                return;
            running = true;
            Task.Run(() =>
            {
                while (running)
                {
                    Debug.WriteLine("Running");
                }
            });
        }
        private void stop_Click(object sender, RoutedEventArgs e)
        {
            running = false;
        }
    }
