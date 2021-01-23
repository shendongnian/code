    public partial class MainPage : PhoneApplicationPage
    {
        TimeSpan vibrateDuration = new TimeSpan(0, 0, 0, 0, 1000);
        System.Threading.Timer timer;
        VibrateController vibrate = VibrateController.Default;
        int timerInterval = 1300;
        SoundEffectInstance alarmSound = PlaySound(@"Alarms/"+alarmSoundString);
        TimeSpan alramDuration; //used to make it timeout after a while
    
        public MainPage()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            timer = new Timer(new TimerCallback(timer_Tick), null, 0, timerInterval);
            alramDuration = TimeSpan.FromSeconds(0);
            alarmSound.Play();
            MessageBoxResult alarmBox = MessageBox.Show("Press OK to stop alarm", "Timer Finished", MessageBoxButton.OK);
    
            if (alarmBox == MessageBoxResult.OK)
            {
                StopAll();
            }
        }
    
        void timer_Tick(object sender)
        {
            //keep track of how long it has been running
            //stop if it has gone too long
            //otheriwse restart
    
            alramDuration = alramDuration.Add(TimeSpan.FromMilliseconds(timerInterval)); 
            if (alramDuration.TotalMinutes > 1)
                StopAll();
            else
                vibrate.Start(vibrateDuration);
        }
        void StopAll()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            vibrate.Stop();
            alarmSound.Stop();
        }
    }
