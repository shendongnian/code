    public partial class AudioPage : Page
    {
        TimeSpan _position;
        DispatcherTimer _timer = new DispatcherTimer();
        public AudioPage()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromMilliseconds(1000);
            _timer.Tick += new EventHandler(ticktock);
            _timer.Start();
        }
        void ticktock(object sender, EventArgs e)
        {
            sliderSeek.Value = media.Position.TotalSeconds;
        }
        // Executes when the user navigates to this page.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            media.Play();
        }
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            media.Pause();
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            media.Stop();
        }
        private void media_MediaOpened(object sender, RoutedEventArgs e)
        {
            _position = media.NaturalDuration.TimeSpan;
            sliderSeek.Minimum = 0;
            sliderSeek.Maximum = _position.TotalSeconds;
        }
        private void sliderSeek_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int pos = Convert.ToInt32(sliderSeek.Value);
            media.Position = new TimeSpan(0, 0, 0, pos, 0);
        }
    }
