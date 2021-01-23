    //
    // Conventional way
    //
    private DataSet GetDataSetConventional(List<FileSearchResultItem> list)
    {
    	DataSet _result = new DataSet();
    	_result.Tables.Add("results");
    	_result.Tables("results").Columns.Add("A");
    	_result.Tables("results").Columns.Add("B");
    	_result.Tables("results").Columns.Add("C");
    	_result.Tables("results").Columns.Add("D");
    	_result.Tables("results").Columns.Add("E");
    	_result.Tables("results").Columns.Add("F");
    	_result.Tables("results").Columns.Add("G");
    
    	foreach (FileSearchResultItem item in list) {
    		DataRow newRow = _result.Tables("results").NewRow();
    		newRow("A") = item.Index;
    		newRow("B") = item.Image;
    		newRow("C") = item.Name;
    		newRow("D") = item.Size;
    		newRow("E") = item.Files;
    		newRow("F") = item.IsDirectory;
    		_result.Tables("results").Rows.Add(newRow);
    	}
    	return _result;
    }
