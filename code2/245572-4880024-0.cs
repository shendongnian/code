    private ObservableCollection<string> _items;
    public ObservableCollection<string> Items
    {
        get 
        {
            if(_items == null){ _items = new ObservableCollection<string>(); } 
            return _itmes; 
        }
        set
        {
            _items = value;
            RaisePropertyChanged("Items");
        }
    }
