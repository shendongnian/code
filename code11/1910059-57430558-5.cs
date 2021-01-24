    var conStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0};Extended Properties='Excel 12.0;HDR={1};IMEX=1'";
    var pathToExcel = @"C:\Users\....xlsx";;
    var udt = new DataTable();
    conStr = string.Format(conStr, pathToExcel, "Yes");
    using (var connExcel = new OleDbConnection(conStr))
    {
    	var cmdExcel = new OleDbCommand();
    	var oda = new OleDbDataAdapter();
    	
    	connExcel.Open();
    	var dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
    	if (dtExcelSchema != null)
    	{
    		//Get the name of First Sheet
    		var sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
    
    		
    		cmdExcel.Connection = connExcel;
    		cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
    	}
    	oda.SelectCommand = cmdExcel;
    	oda.Fill(udt);
    }
                
