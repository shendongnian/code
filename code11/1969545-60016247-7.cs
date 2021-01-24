    class CustomDataGrid : DataGrid
    {
      private int ReorderingColumnOriginalDispalyIndex { get; set; }
      #region Overrides of DataGrid
    
      protected override void OnColumnReordering(DataGridColumnReorderingEventArgs e)
      {
        base.OnColumnReordering(e);
        // Check if the reordering column is the last column
        if (e.Column.DisplayIndex == this.Columns.Count - 1)
        {
          // This is the last column, therefore abort reordering
          e.Cancel = true;
        }    
      }
      protected override void OnColumnReordered(DataGridColumnEventArgse) 
      {
        base.OnColumnReordered(e);
        // Check if the reordered column is the last column (after the pinned column)
        if (e.Column.DisplayIndex == this.Columns.Count - 1)
        {
          // This is the last column.
          // A movable column was moved to an illegal position.
          // Coerce position by moving it to the position before the pinned column
          e.Column.DisplayIndex = this.Columns.Count - 2;
        }    
      }
    
      #endregion
    }
