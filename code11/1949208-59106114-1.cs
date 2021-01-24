    public partial class MainPage : ContentPage
    {
        private static System.Timers.Timer _timer;
        private double _shotClock = 30;
        private DateTime _startTime;
        public MainPage()
        {
            InitializeComponent();
            _timer = new Timer();
            _timer.Interval = 10;
            _timer.Elapsed += OnTimedEvent;  
        }
        private void BtnStart_Clicked(object sender, EventArgs e)
        {
            _startTime = DateTime.UtcNow;
            _timer.Start();
        }
        private void BtnPause_Clicked(object sender, EventArgs e)
        {
            _shotClock -= (DateTime.UtcNow - _startTime).TotalSeconds;
            _timer.Stop();
        }        
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() => {
                var elapsedSinceBtnStartPressed = (DateTime.UtcNow - _startTime).TotalSeconds;
                var remaining = _shotClock - elapsedSinceBtnStartPressed;
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
