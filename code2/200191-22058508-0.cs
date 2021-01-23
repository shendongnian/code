    private void DataGrid_ParametersList_Sorting(object sender, DataGridSortingEventArgs e)
    {
    DataGridColumn column = e.Column;
    
    //prevent the built-in sort from sorting
    e.Handled = true;
    
    ListSortDirection direction = (column.SortDirection != ListSortDirection.Ascending) ? ListSortDirection.Ascending : ListSortDirection.Descending;
    
    //set the sort order on the column
    column.SortDirection = direction;
    
    //use a ListCollectionView to do the sort.
    ListCollectionView lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(DataGrid_ParametersList.ItemsSource);
    
    ParametersListComparer customComparer = new ParametersListComparer();
    customComparer.SortDirection = direction;
    customComparer.SortMemeberPath = column.SortMemberPath;
    
    if (lcv.IsAddingNew) 
    lcv.CommitNew();
    if (lcv.IsEditingItem)
    lcv.CommitEdit();
    
    //apply the sort
    lcv.CustomSort = customComparer;
    }
