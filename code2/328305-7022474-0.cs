    private void TaskDataGrid_LoadingRowGroup(object sender, DataGridRowGroupHeaderEventArgs e)
    {
     
         var RowGroupHeader = (e.RowGroupHeader.DataContext as CollectionViewGroup);
        
                    if (RowGroupHeader != null && RowGroupHeader.Items.Count != 0)
                    {
        
                            MasterTask task = RowGroupHeader.Items[0] as MasterTask;
                            if (task != null && task.SubCategoryName == null)
                                e.RowGroupHeader.Height = 0;
        
        
                   }
     }
