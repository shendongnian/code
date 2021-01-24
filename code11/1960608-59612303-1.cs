            private string isIncluded;
        public string IsIncluded
        {
            get { return isIncluded; }
            set
            {
                isIncluded = value;
                OnPropertyChanged("IsIncluded");
            }
        }
