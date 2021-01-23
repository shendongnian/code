    class Settings
    {
        public event EventHandler YearChanged;
        private int _year;
        public int Year
        {
            get { return _year; }
            set
            {
                if (_year != value)
                {
                    _year = value;
                    OnYearChanged(EventArgs.Empty);
                }
            }
        }
        protected virtual void OnYearChanged(EventArgs e)
        {
            if (YearChanged != null)
                YearChanged(this, e);
        }
    }
