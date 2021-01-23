    DataTable dtTable;
    
    MySQLProcessor.DTTable(mysqlCommand, out dtTable);
    
    // On all tables' rows
    foreach (DataRow dtRow in dtTable.Rows)
    {
    	// On all tables' columns
    	foreach(DataColumn dc in dtTable.Columns)
    	{
    	  var field1 = dtRow[dc].ToString();
    	}
    }
