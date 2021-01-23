    var newTable = new DataTable();
    newTable.Columns.Add("name");
    newTable.Columns.Add("amount");
    foreach (var row as DataRow in dt.Rows) {
        newTable.Rows.Add(new object[] { row["calldate"], row["value"} });
    }
        
