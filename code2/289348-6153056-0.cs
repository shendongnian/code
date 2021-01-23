    // construct an overall sql filter statement
    string sqlFilter = _setttings.SGColumns.GetFilterSQL();
    
    BindingListCollectionView view = CollectionViewSource.GetDefaultView(gridMain.ItemsSource) as BindingListCollectionView;
                   
    if (view != null)
        view.CustomFilter = sqlFilter;      // "XGROUP = 'E' AND GEOG = 'U'";
    
    if (view != null && _dv.Count == 0)
    {
        gridMain.ItemsSource = null;
        gridMain.Items.Add("hello");
        _RowHeightTemp = gridMain.RowHeight;
        gridMain.RowHeight = 0;
    }
    else
    {
        if (gridMain.Items.Count == 1 && gridMain.Items[0].ToString() == "hello")
        {
            gridMain.Items.Clear();
            gridMain.ItemsSource = _dv;
            view = CollectionViewSource.GetDefaultView(gridMain.ItemsSource) as BindingListCollectionView;
            view.CustomFilter = sqlFilter;
            gridMain.RowHeight = _RowHeightTemp;
        }
    }
