    int FindCellRowIndex( string columnName, string rowContent ){
        foreach (DataGridViewRow row in dgView.Rows){             
               foreach (DataGridViewCell cell in row.Cells){
                   if( cell.OwningColumn.Name() == columnName && cell.Value != null && Convert.Tostring(cell.Value) == rowContent)
                      return row.Index;
               }             
        }
        return -1;
    }
