    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer timer =
            new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            HelloWorldLabel.Visibility = HelloWorldLabel.Visibility == Visibility.Visible
                ? Visibility.Hidden : Visibility.Visible;
        }
    }
