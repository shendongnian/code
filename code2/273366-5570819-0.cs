    void InitializeDataContext()
    {
        var ovens = (from s
                     in dbcontext.Ovens
                     select s).ToList();
        ICollectionView view = new CollectionViewSource
        {
            Source = ovens
        }.View;
        
        ViewSource = view;
        ovenListView.ItemsSource = ViewSource;
    }
