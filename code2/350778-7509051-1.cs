    //declaration
    public ObservableCollection<WarrantNameDataView> NameResult { get; set }
    
    //in the ViewModel constructor do this
    NameResult = new ObservableCollection<WarrantNameDataView>();
    
    //then replace the original line in your method with:
    //EDIT: ObservableCollection has no AddRange.  Either loop through 
    //entities and add them to the collection or see OP's answer.
    //NameResult.AddRange(entities);
