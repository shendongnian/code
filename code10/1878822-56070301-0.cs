    private ObservableCollection<CbItem> CbItemList = new ObservableCollection<CbItem>();
    public ObservableCollection<CbItem> CbItemLists
    {
        get { return CbItemList; }
        set { this.SetProperty(ref this.CbItemList, value); }
    }
