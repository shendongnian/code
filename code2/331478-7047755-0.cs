    DataSet dataSet = new DataSet("MyDataSet");
    DataTable dataTable = dataSet.Tables.Add("JavaScriptLibraries");
    
    DataColumn[] dataColumns =
        new[] {
            new DataColumn("Id", typeof(Int32))
                {
                    AutoIncrement = true, 
                    AllowDBNull = false, 
                    AutoIncrementSeed = 1
                }, 
            new DataColumn("Name", typeof(String))
        };
    dataTable.Columns.AddRange(dataColumns);
    dataTable.PrimaryKey = new[] { dataTable.Columns["Id"] };
    
    DataRow dataRow1 = dataTable.NewRow();
    dataRow1["Name"] = "jQuery";
    dataTable.Rows.Add(dataRow1);
    
    DataRow dataRow2 = dataTable.NewRow();
    dataRow2["Name"] = "MooTools";
    dataTable.Rows.Add(dataRow2);
    
    // Copy the dataset
    DataSet tempDataSet = dataSet.Clone();
    DataTable tempDataTable = tempDataSet.Tables["JavaScriptLibraries"];
    DataRow[] tempRows = dataSet.Tables["JavaScriptLibraries"].Select("Name = 'jQuery'");
    
    // Import rows to copy of table
    foreach (var tempRow in tempRows)
    {
        tempDataTable.ImportRow(tempRow);
    }
    
    foreach (DataRow tempRow in tempDataTable.Rows)
    {
        // Find existing row by PK, then update it
        DataRow originalRow = dataTable.Rows.Find(tempRow["Id"]);
        originalRow["Name"] = "Updated Name";
    }
    
    // Load new data using LoadDataRow()
    object[] newRow = new[] { null, "New Row" };
    dataTable.BeginLoadData();
    dataTable.LoadDataRow(newRow, true);
    dataTable.EndLoadData();
