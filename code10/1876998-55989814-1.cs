        private string _timeFormat;
        public string TimeFormat
        {
            get { return _timeFormat; }
            private set
            {
                _timeFormat = value;
                OnPropertyChanged(nameof(TimeFormat));
            }
        }
