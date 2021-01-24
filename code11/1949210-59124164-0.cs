public partial class MainPage : ContentPage
    {
        private static System.Timers.Timer _timer;
        private double _shotClock;
        private DateTime _startTime;
        public MainPage()
        {
            InitializeComponent();
            _timer = new Timer();
            _timer.Interval = 10;
            _timer.Elapsed += OnTimedEvent;
            _shotClock = 30.00;
        }
        private void BtnStart_Clicked(object sender, EventArgs e)
        {
            _startTime = DateTime.UtcNow;     
            _timer.Start();
        }
        private void BtnPause_Clicked(object sender, EventArgs e)
        {
            
            
            _timer.Stop();
            var elapsedSinceBtnPausePressed = (DateTime.UtcNow - _startTime).TotalSeconds;
            _shotClock -= elapsedSinceBtnPausePressed;
        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            var elapsedSinceBtnStartPressed = (DateTime.UtcNow - _startTime).TotalSeconds;
            var remaining = _shotClock - elapsedSinceBtnStartPressed;
            Device.BeginInvokeOnMainThread(() => {
                
                if (remaining > 1.00)
                {
                    lblTimer.Text = Math.Floor(remaining).ToString();
                }
                else if (remaining <= 1.00 && remaining > 0.00)
                {
                    lblTimer.Text = Math.Round(remaining, 2).ToString();
                }
                else
                {
                    lblTimer.Text = "0";
                    _timer.Stop();
                }
            });
        }
    }
