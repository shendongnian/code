        private ObservableCollection<Data>_dataCollection ;
        public ObservableCollection<Data> DataCollection 
        {
            get { return _dataCollection ; }
            set
            {
                _dataCollection = value;
                RaisePropertyChanged("DataCollection ");
            }
        }
