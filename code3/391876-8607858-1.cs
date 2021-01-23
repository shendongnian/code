    public partial class MainPage : PhoneApplicationPage
    {
        TimeSpan vibrateDuration = new TimeSpan(0, 0, 0, 0, 1000);
        System.Threading.Timer timer;
        VibrateController vibrate = VibrateController.Default;
    
        public MainPage()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            timer = new Timer(new TimerCallback(timer_Tick), null, 0, 1300);
    
            MessageBoxResult alarmBox = MessageBox.Show("Press OK to stop alarm", "Timer Finished", MessageBoxButton.OK);
    
            if (alarmBox == MessageBoxResult.OK)
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                vibrate.Stop();
            }
        }
    
        void timer_Tick(object sender)
        {
            vibrate.Start(vibrateDuration);
        }
    }
