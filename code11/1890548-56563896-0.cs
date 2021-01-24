    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly Random random = new Random();
        public MainWindowViewModel()
        {
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        private int randomRpm;
        public int RandomRpm
        {
            get { return randomRpm; }
            set
            {
                randomRpm = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs(nameof(RandomRpm)));
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            RandomRpm = random.Next(0, 3001);
        }
    }
