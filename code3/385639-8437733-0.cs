    string connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\MyExcelFile.xls;Extended Properties=\"Excel 8.0;HDR=YES\"";
    using (var conn = new System.Data.OleDb.OleDbConnection(connString)) {
    	conn.Open();
    	System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand("Select * From [SheetName$]", conn);
    	OleDbDataReader reader = cmd.ExecuteReader();
    	int firstNameOrdinal = reader.GetOrdinal("First Name");
    	int lastNameOrdinal = reader.GetOrdinal("Last Name");
    	while (reader.Read()) {
    		Console.WriteLine("First Name: {0}, Last Name: {1}", 
    			reader.GetString(firstNameOrdinal), 
    			reader.GetString(lastNameOrdinal));
    	}
    }
