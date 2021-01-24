    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }
        private void Start()
        {
            timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(2) };
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            HelloWorldLabel.Visibility = HelloWorldLabel.Visibility == Visibility.Visible
                ? Visibility.Hidden : Visibility.Visible;
        }
    }
