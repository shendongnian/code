        private bool gridVisible;
        public bool GridVisible
        {
            get { return gridVisible; }
            set 
            { 
                gridVisible = value; 
                OnPropertyChanged("GridVisible"); 
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
