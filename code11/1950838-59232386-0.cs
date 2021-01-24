    foreach (DataColumn column in dtafter.Columns)
    {
     string cName = dtafter.Rows[0][column.ColumnName].ToString();
    if (!table.Columns.Contains(cName) && cName != "")
    {
         column.ColumnName = cName;
    }
    }
    dtafter.Rows[0].Delete(); //If you don't need that row any more
