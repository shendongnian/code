    public class Schedule : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    
        private string _monthWeek;
        public string MonthWeek
        {
            get { return _monthWeek; }
            set
            {
                if (value != _monthWeek)
                {
                    _monthWeek = value;
                    OnPropertyChanged("MonthWeek");
                }
            }
        }
        
        // And so on for other properties...
    
    }
