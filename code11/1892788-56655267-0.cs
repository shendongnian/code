    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }
        private void Start()
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            HelloWorldLabel.Visibility = HelloWorldLabel.Visibility == Visibility.Visible
                ? Visibility.Hidden : Visibility.Visible;
        }
    }
