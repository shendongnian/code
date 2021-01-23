    foreach (DataColumn column in table.Columns)
    {
        string cName = table.Rows[0][column.ColumnName].ToString();
        if (!table.Columns.Contains(cName) && cName != "")
        {
             column.ColumnName = table.Rows[0][column.ColumnName].ToString() != "" ? 
             cName : column.ColumnName;
        }
                    
    }
