     foreach (DataGridViewColumn column in dgv.Columns)
     {
           if (column.Visible)
           {
               dt.Columns.Add(column.Name, typeof(string));
           }
     }
