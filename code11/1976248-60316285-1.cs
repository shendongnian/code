    this.dataGrid.SortColumnsChanged += DataGrid_SortColumnsChanged;
    private void DataGrid_SortColumnsChanged(object sender, GridSortColumnsChangedEventArgs e)
    {
        dataGrid.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.ApplicationIdle,
             new Action(() =>
             {
                 this.dataGrid.ExpandAllDetailsView();
    
             }));
    }
