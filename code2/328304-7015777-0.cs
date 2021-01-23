    private void TaskDataGrid_LoadingRowGroup(object sender, DataGridRowGroupHeaderEventArgs e)
    {
        string RowGroupHeader  =  (e.RowGroupHeader.DataContext as ParentVM).VMProperty
        if(RowGroupHeader == string.Empty)
        {
          e.RowGroupHeader.Height = 0;
        }
    }
     
