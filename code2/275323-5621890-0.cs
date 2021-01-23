        ICollectionView ViewFilter;
        private string _Filter;
        public string Filter
        {
            get { return _Filter; }
            set
            {
                _Filter = value;
                RaisePropertyChanged("Filter");
            }
        }
