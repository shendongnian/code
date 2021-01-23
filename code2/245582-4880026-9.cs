    private ObservableCollection<string> _items; 
    public ObservableCollection<string> Items {
        get {
            if (_items == null) { 
               // Create a new collection and subscribe to the event
               _items=new ObservableCollection<string>(); 
               _items.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler
            }
            return _items;
        }
    }
    void _items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e) {
        // Here you will be informed, if the content of the collection has been changed.  
    } 
