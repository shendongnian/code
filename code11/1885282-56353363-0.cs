    public static void ToExcelFile(this DataTable dataTable, string filePath, bool overwriteFile = true)
    {
    	var backupFolder = Path.GetDirectoryName(filePath) ?? "";
    
    	if (!Directory.Exists(backupFolder))
    		Directory.CreateDirectory(backupFolder);
    
    	if (File.Exists(filePath) && overwriteFile)
    		File.Delete(filePath);
    
    	using (var connection = new OleDbConnection())
    	{
    		connection.ConnectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};" +
    									  "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
    		connection.Open();
    		using (var command = new OleDbCommand())
    		{
    			command.Connection = connection;
    			var columnNames = (from DataColumn dataColumn in dataTable.Columns select dataColumn.ColumnName).ToList();
    			var tableName = !string.IsNullOrWhiteSpace(dataTable.TableName) ? dataTable.TableName : Guid.NewGuid().ToString();
    			command.CommandText = $"CREATE TABLE [{tableName}] ({string.Join(",", columnNames.Select(c => $"[{c}] VARCHAR").ToArray())});";
    			command.ExecuteNonQuery();
    			foreach (DataRow row in dataTable.Rows)
    			{
    				var rowValues = (from DataColumn column in dataTable.Columns select (row[column] != null && row[column] != DBNull.Value) ? row[column].ToString() : string.Empty).ToList();
    				command.CommandText = $"INSERT INTO [{tableName}]({string.Join(",", columnNames.Select(c => $"[{c}]"))}) VALUES ({string.Join(",", rowValues.Select(r => $"'{r}'").ToArray())});";
    				command.ExecuteNonQuery();
    			}
    		}
    
    		connection.Close();
    	}
    }
