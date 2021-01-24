    private ObservableCollection<MyItem> items;
    
    public ObservableCollection<MyItem> Items
    {
    	get { return items ?? (items = new ObservableCollection<MyItem>()); }
    }
