    //First, copy structure of DataTable into new one
    DataTable dt = ((DataTable)dgv.DataSource).Clone();
    
    //Add all selected cells into this DataTable
    for (int i = 0; i < dgv.Rows.Count; i++)
     {
         dt.Rows.Add();
         for (int j = 0; j < dgv.ColumnCount; j++)
         {
            if (dgv.Rows[i].Cells[j].Selected == true)
            {
               dt.Rows[i][j] = dgv.Rows[i].Cells[j].Value;
            }
         }
      }
       dt.AcceptChanges();
    
     // Then create a new DataTable without blank rows
     DataTable final_dt = dt.Rows.Cast<DataRow>()
     .Where(row => !row.ItemArray.All(field => field is DBNull ||
     string.IsNullOrWhiteSpace(field.ToString()))).CopyToDataTable();
