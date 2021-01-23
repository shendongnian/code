    ... In the constructor or initialization somewhere
    
    ItemCollection view = PlaylistDataGrid.Items as ItemCollection;
    ((INotifyCollectionChanged)view.SortDescriptions).CollectionChanged += PlaylistDataGrid_ItemsCollectionChanged;
    
    ...
    
    private void MyDataGrid_ItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        // This is how we detect if a sorting event has happend on the grid.
        if (e.NewItems != null &&
            e.NewItems.Count == 1 &&
            (e.NewItems[0] is SortDescription))
        {
            MyItem[] myItems = new MyItem[MyDataGrid.Items.Count]; // MyItem would by type T of whatever is in the SortableObservableCollection
            MyDataGrid.Items.CopyTo(myItems, 0);
            MyDataSource.ApplySort(myItems);  // MyDataSource would be the SortableObservableCollection
        }
    } 
