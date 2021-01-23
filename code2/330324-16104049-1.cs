    private ObservableCollection<ItemGridVM> _getAllItems;
    public ObservableCollection<ItemGridVM> GetAllItems
    {
    get
                {
                    return _getAllItems;
                }
                set
                {
                    _getAllItems = value;
                    //if u want Observable Collection to get updated on edit either 
                    RaisePropertyChanged("GetAllItems");
                   
                }
    }
