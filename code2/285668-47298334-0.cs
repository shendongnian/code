    public class Sample : INotifyPropertyChanged
    {
        private string _propString;
        private int _propInt;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public string PropString
        {
            get { return _propString; }
            set
            {
                // do not trigger change event if values are the same
                if (Equals(value, _propString)) return;
                _propString = value;
                OnPropertyChanged();
            }
        }
    
        public int PropInt
        {
            get { return _propInt; }
            set
            {
                // do not allow negative numbers, but always trigger a change event
                _propInt = value < 0 ? 0 : value;
                OnPropertyChanged();
            }
        }
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
