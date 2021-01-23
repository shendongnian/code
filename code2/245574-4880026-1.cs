    private ObservableCollection<string> _items;
    public ObservableCollection<string> Items {
        get {
            if (_items == null) { 
               Items=new ObservableCollection<string>(); 
            }
            return _items;
        }
        set {
    
            if (null != _items) {
                _items.CollectionChanged -= new System.Collections.Specialized.NotifyCollectionChangedEventHandler(_items_CollectionChanged);
            }
                    
            _items = value;
            if (null != _items) {
                _items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(_items_CollectionChanged);
    
            }
            // Here you will be informed, when the collection itselfs has been changed
            RaisePropertyChanged("Items");
        }
    }
    
    void _items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
        // Here you will be informed, if the content of the collection has been changed.  
    } 
