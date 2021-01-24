    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        public MainPage()
        {
            this.InitializeComponent();
            SetFakeData();
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
        }
    
        private int _airTemp;
        public int AirTemp
        {
            get
            {
                return _airTemp;
            }
            set
            {
                _airTemp = value;
                OnPropertyChanged();
            }
        }
    
        private void SetFakeData()
        {
            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.5);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
    
        private void Timer_Tick(object sender, object e)
        {
            do
            {
                AirTemp += 1;
    
            } while (AirTemp > 100);
    
        }
    }
