        public double Red
        {
            get { return FillValue.Red; }
            set
            {
                FillValue.Red = value;
                NotifyPropertyChanged("Red");
                NotifyPropertyChanged("FillValue");
            }
        }
