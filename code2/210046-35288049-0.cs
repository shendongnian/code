    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _timer.Interval = TimeSpan.FromMilliseconds(1000);
            _timer.Tick += new EventHandler(ticktock);
            _timer.Start();
            Open(@"filename.mp3");
        }
        public void Open(string fileName)
        {
            var uriPath = "file:///" + fileName.Replace("\\", "/");
            media.Source=new Uri(uriPath);
        }
        TimeSpan _position;
        DispatcherTimer _timer = new DispatcherTimer();
        
        void ticktock(object sender, EventArgs e)
        {
            if (!sliderSeek.IsMouseCaptureWithin)
                sliderSeek.Value = media.Position.TotalSeconds;
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
        private void sliderSeek_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {           
            int pos = Convert.ToInt32(sliderSeek.Value);
            media.Position = new TimeSpan(0, 0, 0, pos, 0);
        }
        private void sliderSeek_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sliderSeek.IsMouseCaptureWithin)
            {
                int pos = Convert.ToInt32(sliderSeek.Value);
                media.Position = new TimeSpan(0, 0, 0, pos, 0);
            }
        }
    }
