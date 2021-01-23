    private ICollectionView cvs;
    
    ctor(){
        /*your default init stuff*/
        /*....*/
        cvs = CollectionViewSource.GetDefaultView(items);
        view.SortDescriptions.Add(new SortDescription("Index",ListSortDirection.Ascending));
    }
