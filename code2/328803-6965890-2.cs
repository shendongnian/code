    public partial class AnotherScreen : PhoneApplicationPage
    {
        private Timer _timer;
        private int _timeSpan;
        public AnotherScreen()
        {
            InitializeComponent();
            _timer = new Timer(TimerTick,null,TimeSpan.Zero,TimeSpan.FromMinutes(2));
            MouseEnter += (s, e) => _timeSpan = 0;
        }
        private void TimerTick(object obj)
        {
            _timeSpan += 1;
            if (_timeSpan > 120)
            {
                Dispatcher.BeginInvoke(() =>NavigationService.Navigate(new Uri("/LoginScreen.xaml", UriKind.Relative)));
            }
        }
    }
                  
