    string sql = "SELECT F1, F2, F3, F4, F5 FROM [sheet1$] WHERE F1 IS NOT NULL";
    
    OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + PrmPathExcelFile + @";Extended Properties=""Excel 8.0;IMEX=1;HDR=NO;TypeGuessRows=0;ImportMixedTypes=Text""");
    
    OleDbCommand cmd = new OleDbCommand(sql, connection);
    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
    
    DataSet ds = new DataSet();
    ds.Tables.Add("xlsImport", "Excel");
    da.Fill(ds, "xlsImport");
    
    // Remove the first row (header row)
    DataRow rowDel = ds.Tables["xlsImport"].Rows[0];
    ds.Tables["xlsImport"].Rows.Remove(rowDel);
    
    ds.Tables["xlsImport"].Columns[0].ColumnName = "LocationID";
    ds.Tables["xlsImport"].Columns[1].ColumnName = "PartID";
    ds.Tables["xlsImport"].Columns[2].ColumnName = "Qty";
    ds.Tables["xlsImport"].Columns[3].ColumnName = "UserNotes";
    ds.Tables["xlsImport"].Columns[4].ColumnName = "UserID";
    
    connection.Close(); 
    
      var data = ds.Tables["xlsImport"].AsEnumerable();
        var query = data.Where(x => x.Field<string>("LocationID") == "COOKCOUNTY").Select(x =>
                    new Contact
                    {
                        LocationID= x.Field<string>("LocationID"),
                        PartID = x.Field<string>("PartID"),
                        Quantity = x.Field<string>("Qty"),
                        Notes = x.Field<string>("UserNotes"),
                        UserID = x.Field<string>("UserID")
                    });
