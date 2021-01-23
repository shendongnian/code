    OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;" + 
    "Data Souce=" + source);                          
    conn.Open(); 
    OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * From " + table, conn);
    OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
    
    adapter.InsertCommand = new OleDbCommand(String.Format("INSERT INTO {0} ([GUID], [fieldName]) Values (@guid,@fieldName);", table), conn);
				
    DataTable dataTable = new DataTable(table);
    adapter.Fill( dataTable);
    DataRow row = dataTable.NewRow();
    row [ fieldName ] = fieldValue;
    // eg: row [ "GUID" ] = System.Guid.NewGuid().ToString(); // Do this for all attributes/fields.
    dataTable.Rows.Add(row);
    
    adapter.InsertCommand.Parameters.Add(new OleDbParameter("@fieldName",row[fieldName]));
    // eg: adapter.InsertCommand.Parameters.Add(new OleDbParameter("@guid",row["GUID"]));
    adapter.Update(dataTable);
