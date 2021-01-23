        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        private int _addition;
        public Int32 Addition
        {
            get { return _addition; }
            set
            {
                _addition= value;
                RaisePropertyChanged("Addition");
            }
        }
