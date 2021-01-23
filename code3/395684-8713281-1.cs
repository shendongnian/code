    foreach (DataColumn column in table.Columns)
    {
        string cName = table.Rows[0][column.ColumnName].ToString();
        if (!table.Columns.Contains(cName) && cName != "")
        {
             column.ColumnName = cName != "" ? 
             cName : column.ColumnName;
        }
                    
    }
    
    table.Rows[0].Delete(); //If you don't need that row any more
