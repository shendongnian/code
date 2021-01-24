    private ObservableCollection<CbItem> CbItemList 
    public ObservableCollection<CbItem> CbItemLists
    {
        get { return CbItemList ?? (CbItemList = new ObservableCollection<CbItem>()); }
        set { this.SetProperty(ref this.CbItemList, value); }
    }
