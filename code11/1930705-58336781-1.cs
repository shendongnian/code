        private double _timeStampMinX;
        public double TimeStampMinX
        {
            get
            {
                return _timeStampMinX;
            }
            set
            {
                if (_timeStampMinX == value)
                    return;
                _timeStampMinX = value;
                OnPropertyChanged("TimeStampMinX");
            }
        }
        private double _timeStampMaxX;
        public double TimeStampMaxX
        {
            get
            {
                return _timeStampMaxX;
            }
            set
            {
                if (_timeStampMaxX == value)
                    return;
                _timeStampMaxX = value;
                OnPropertyChanged("TimeStampMaxX");
            }
        }
        private DateTime _timeStampMin;
        public DateTime TimeStampMin
        {
            get
            {
                return _timeStampMin;
            }
            set
            {
                if (_timeStampMin == value)
                    return;
                _timeStampMin = value;
                TimeStampMinX = value.Ticks;
                OnPropertyChanged("TimeStampMin");
            }
        }
        private DateTime _timeStampMax;
        public DateTime TimeStampMax
        {
            get
            {
                return _timeStampMax;
            }
            set
            {
                if (_timeStampMax == value)
                    return;
                _timeStampMax = value;
                TimeStampMaxX = value.Ticks;
                OnPropertyChanged("TimeStampMax");
            }
        }
