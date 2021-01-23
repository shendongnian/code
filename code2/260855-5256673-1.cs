    ControlTemplate _defaultRowControlTemplate = null;
    ControlTemplate _newRowControlTemplate = null;
    private void dataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
    {
        if (_defaultRowControlTemplate == null)
        {
            _defaultRowControlTemplate = e.Row.Template;
        }
        if (_newRowControlTemplate == null)
        {
            _newRowControlTemplate = dataGrid.FindResource("NewRow_ControlTemplate") as ControlTemplate;
        }
        if (e.Row.Item == CollectionView.NewItemPlaceholder)
        {
            e.Row.Template = _newRowControlTemplate;
            e.Row.UpdateLayout();
        }
    }
    private void dataGrid_UnloadingRow(object sender, DataGridRowEventArgs e)
    {
        if (e.Row.Item == CollectionView.NewItemPlaceholder && e.Row.Template != _defaultRowControlTemplate)
        {
            e.Row.Template = _defaultRowControlTemplate;
            e.Row.UpdateLayout();
        }
    }
    private void Row_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DataGridRow row = sender as DataGridRow;
        if (row.Item == CollectionView.NewItemPlaceholder && row.Template == _newRowControlTemplate)
        {
            // for a new row update the template and open for edit
            row.Template = _defaultRowControlTemplate;
            row.UpdateLayout();
            dataGrid.CurrentItem = row.Item;
            DataGridCell cell = DataGridHelper.GetCell(dataGrid, dataGrid.Items.IndexOf(row.Item), 0);
            cell.Focus();
            dataGrid.BeginEdit();
        }
    }
    private void dataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
    {
        IEditableCollectionView iecv = CollectionViewSource.GetDefaultView((sender as DataGrid).ItemsSource) as IEditableCollectionView;
        if (iecv.IsAddingNew)
        {
            // need to wait till after the operation as the NewItemPlaceHolder is added after
            Dispatcher.Invoke(new DispatcherOperationCallback(ResetNewItemTemplate), DispatcherPriority.ApplicationIdle, dataGrid);
        }
    }
    private object ResetNewItemTemplate(object arg)
    {
        DataGridRow row = DataGridHelper.GetRow(dataGrid, dataGrid.Items.Count - 1);
        if (row.Template != _newRowControlTemplate)
        {
            row.Template = _newRowControlTemplate;
            row.UpdateLayout();
        }
        return null;
    }
