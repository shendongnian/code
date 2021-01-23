    private void gridView1_ShowingEditor(object sender, CancelEventArgs e)
    {
         if (gridView1.FocusedColumn.FieldName == "Text"
              && !IsAllowingEdit(gridView1, gridView1.FocusedRowHandle))
         {
           e.Cancel = true;
         }
    }
    
    private bool IsAllowingEdit(DevExpress.XtraGrid.Views.Grid.GridView view,int row)
    {
         try
         {
            bool val = Convert.ToBoolean(view.GetRowCellValue(row, "AllowEdit"));
            return val;
         }
         catch
         {
             return false;
         }
     }
