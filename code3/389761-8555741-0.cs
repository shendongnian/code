    private ObservableCollection<EMSMenuItem> _level2MenuItems;
    public ObservableCollection<EMSMenuItem> Level2MenuItems
    {
        get { return _level2MenuItems; }
        set 
         {
            _level2MenuItems = value; 
            RaisePropertyChanged("Level2MenuItems");
         }
     }
