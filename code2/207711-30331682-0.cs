    private ObservableCollection<string> _myItems = new ObservableCollection<string>(new[] { "test1", "test2", "test3" });
    public ObservableCollection<string> MyItems
    {
        get { return _myItems; }
        set { _myItems = value; }
    }
