    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer timer = new DispatcherTimer();
        private DateTime endTime;
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(OnTimerTick);
            timer.Start();
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            if (endTime < now)
            {
                endTime = now.AddSeconds(300);
            }
            label.Content = (endTime - now).ToString(@"mm\:ss");
        }
    }
