     private IEnumerable<SourceControlItemViewBaseModel> _items;
        public IEnumerable<SourceControlItemViewBaseModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }
    
