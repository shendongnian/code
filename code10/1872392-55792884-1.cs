    var rows = GetDataGridRows(datagrid);
    
    foreach (DataGridRow r in rows)
     {
           var rowHeight = r?.Height;
     }
      public IEnumerable<DataGridRow> GetDataGridRows(System.Windows.Controls.DataGrid grid)
            {
                var itemsSource = grid.ItemsSource as IEnumerable;
                if (null == itemsSource) yield return null;
                foreach (var item in itemsSource)
                {
                    var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                    if (null != row) yield return row;
                }
            }
