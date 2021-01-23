    int FindCellRowIndex( string columnName, string rowContent ){
        foreach (DataGridViewColumn col in dgView.Columns){
             if( col.Name() == columnName ){
                  foreach (DataGridViewCell cell in col.Cells){
                      if( cell.Value != null && Convert.Tostring(cell.Value) == rowContent)
                          return cell.OwningRow.Index;
                  }
             }
        }
        return -1;
    }
