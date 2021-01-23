    public class ClockViewModel : INotifyPropertyChanged
    {
        private readonly System.Timers.Timer _timer;
    
        public ClockViewModel()
        {
            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }
    
        private void _timer_Elapsed(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            DigitalTime = now.ToString("hh:mm:ss tt");
            SecondAngle = now.Second * 6;
            MinuteAngle = now.Minute * 6; 
            HourAngle = (now.Hour * 30) + (now.Minute * 0.5);
        }
        
        private strin _digitalTime;
        public strin DigitalTime
        {
            get { return _digitalTime;}
            set
            {
                _digitalTime = value;
                OnPropertyChanged("DigitalTime");
            }
        }
        
    
        private double _hourAngle;
        public double HourAngle
        {
            get { return _hourAngle;}
            set
            {
                _hourAngle = value;
                OnPropertyChanged("HourAngle");
            }
        }
        
    
        private double _minuteAngle;
        public double MinuteAngle
        {
            get { return _minuteAngle;}
            set
            {
                _minuteAngle = value;
                OnPropertyChanged("MinuteAngle");
            }
        }
        
        private double _secondAngle;
        public double SecondAngle
        {
            get { return _secondAngle;}
            set
            {
                _secondAngle = value;
                OnPropertyChanged("SecondAngle");
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
