    class CustomDataGrid : DataGrid
    {
      #region Overrides of DataGrid
    
      protected override void OnColumnReordering(DataGridColumnReorderingEventArgs e)
      {
        // Check if the reordering column is the last column
        if (e.Column.DisplayIndex == this.Columns.Count - 1)
        {
          // This is the last column, therefore abort reordering
          e.Cancel = true;
        }
    
        base.OnColumnReordering(e);
      }
    
      #endregion
    }
