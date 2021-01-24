    private const String SelectDataTableTemplate = @"SELECT ... FROM {0}";
    ...
    var originalDataTable = GetDataTable();
    var copyOfDataTable = originalDataTable.Copy();
    foreach(var row in copyOfDataTable.Rows)
    {
    	row.AcceptChanges(); // sets DataRowState.Unchanged
    	row.SetAdded();	
    }
    var dataAdapter = new OracleDataAdapter(
    	selectCommandText: String.Format(SelectDataTableTemplate, "AnotherTableName", 
    	selectConnection: _connection));
    dataAdapter.Update(copyOfDataTable);
