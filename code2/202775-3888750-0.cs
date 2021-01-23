    List<MainClass> mainList = ...
    foreach(MainClass main in mainList)
    {
        ICollectionView view = CollectionViewSource.GetDefaultView(main.ExtraInfo);
        view.Filter = ExtraInfoFilter;
    }
    
    bool ExtraInfoFilter(object obj)
    {
        ExtraInfo item = (ExtraInfo)obj;
    
        return item.City == "New York";
    }
