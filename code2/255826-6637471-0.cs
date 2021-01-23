        private DateTime _FromDate= DateTime.Today.AddDays(-1);
        public DateTime FromDate
        {
            get { return _FromDate; }
            set
            {
                if (_FromDate != value)
                {
                    _FromDate = value;
                    if (value > _ToDate)
                    {
                        _ToDate = value;
                        OnPropertyChanged("ToDate");
                    }
                }
                OnPropertyChanged("FromDate");
            }
        }
        private DateTime _ToDate = DateTime.Today;
        public DateTime ToDate
        {
            get { return _ToDate; }
            set
            {
                if (_ToDate != value)
                {
                    _ToDate = value;
                    if (value < _FromDate)
                    {
                        _FromDate = value;
                        OnPropertyChanged("FromDate");
                    }
                }
                OnPropertyChanged("ToDate");
            }
        }
