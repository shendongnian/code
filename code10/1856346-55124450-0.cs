    public DateTime MorningCheckOut
        {
            get => _morningCheckOut;
            set
            {
                if (value == _morningCheckOut) return;
                _morningCheckOut = new DateTime(Day.Year, Day.Month, Day.Day, value.Hour, value.Minute, value.Second);               
                OnPropertyChanged();
            }
        }
