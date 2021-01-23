    DataTable dtTable;
    
    MySQLProcessor.DTTable(mysqlCommand, out dtTable);
    
    // on all table's rows
    foreach (DataRow dtRow in dtTable.Rows)
    {
    	// on all table's columns
    	foreach(DataColumn dc in dtTable.Columns)
    	{
    	  var field1 = dtRow[dc].ToString();
    	}
    }
