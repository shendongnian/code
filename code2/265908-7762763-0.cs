    DataTable dataTable = reportData.Tables[0];
    
    //Second DataTable
    DataTable dtSecond = reportData.Tables[1];
    
    foreach (DataColumn myCol in dtSecond.Columns)
    {
    
        sbc.ColumnMappings.Add(myCol.ColumnName, myCol.ColumnName);
        dataTable.Columns.Add(myCol.ColumnName);
        dataTable.Rows[0][myCol.ColumnName] = dtSecond.Rows[0][myCol];
    }
    
    //Finally Perform the BulkCopy
    
    sbc.WriteToServer(dataTable);
