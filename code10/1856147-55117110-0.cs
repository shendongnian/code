    private void AutoGeneratingColEvents()
    {
        var orders = OrderInfoCollection;
        OrderInfoCollection = null;
        OrderInfoCollection = orders;
    }
    ObservableCollection<ExcelModel> orderCollection;
    public ObservableCollection<ExcelModel> OrderInfoCollection
    {
        get { return orderCollection; }
        set { orderCollection = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OrderInfoCollection))); }
    }
