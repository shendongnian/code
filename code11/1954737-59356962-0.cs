    public static class DatagridBehaviour
    {
        public static DataGrid GetSyncSortingWith(DependencyObject obj)
        {
            return (DataGrid)obj.GetValue(SyncSortingWithProperty);
        }
        public static void SetSyncSortingWith(DependencyObject obj, DataGrid value)
        {
            obj.SetValue(SyncSortingWithProperty, value);
        }
        public static readonly DependencyProperty SyncSortingWithProperty = DependencyProperty.RegisterAttached("SyncSortingWith", typeof(DataGrid), typeof(DatagridBehaviour), new PropertyMetadata(OnSyncSortingWithChanged));
        private static void OnSyncSortingWithChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DataGrid source)
            {
                source.Sorting -= DataGridSorting;
                if (e.NewValue is DataGrid other)
                {
                    other.Sorting += DataGridSorting;
                    source.Sorting += DataGridSorting;
                }
                if (e.OldValue is DataGrid previous)
                {
                    previous.Sorting -= DataGridSorting;
                }
            }
        }
        private static void DataGridSorting(object sender, DataGridSortingEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                DataGridColumn column = dataGrid.Columns[0];
                dataGrid.Items.SortDescriptions.Clear();
                dataGrid.Items.SortDescriptions.Add(new SortDescription(column.SortMemberPath, column.SortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending));
                dataGrid.Items.Refresh();
            }
        }
    }
