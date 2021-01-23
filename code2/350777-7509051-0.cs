    //declaration
    public ObservableCollection<WarrantNameDataView> NameResult { get; set }
    
    //in the ViewModel constructor do this
    NameResult = new ObservableCollection<WarrantNameDataView>();
    
    //then replace the original line in your method with:
    NameResult.AddRange(entities);
