        private ObservableCollection<ScannedCheck> scannedChecksCollection;
        public ObservableCollection<ScannedCheck> ScannedChecksCollection {
            get
            {
                return scannedChecksCollection; 
            }
            set
            {
                if (value != scannedChecksCollection)
                {
                    value = scannedChecksCollection;
                    NotifyPropertyChanged("ScannedChecksCollection");
                }
            }
        }
        private void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
