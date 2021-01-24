    var tableColumns = string.Join(",", columns.Cast<DataColumn>().Select(x => "[" + x.ColumnName + "]"));
    var insertBase = $"INSERT into {SheetName} ({tableColumns}) VALUES(";
    int columnCount = table.Columns.Count;
    foreach (DataRow row in table.Rows)
    {
    	Excel_OLE_Cmd.Parameters.Clear(); // Since you are reusing the command you have to clear the parameters
    
    	var command = new StringBuilder(insertBase);
    	var index = table.Rows.IndexOf(row);
    
        // I will assume you always have at least one column, otherwise these lines would fail
        // Add the first row before the loop that way we don't have to delete the end comma
    	var param = $"@param_{index}_0";
    	command.Append(param);
    	Excel_OLE_Cmd.Parameters.AddWithValue(param, table.Rows[index].ItemArray[0]);
    	for (int i = 1; i < columnCount; ++i)
    	{
            param = $"@param_{index}_{i}"
    		command.Append("," + param);
    		Excel_OLE_Cmd.Parameters.AddWithValue(param, table.Rows[index].ItemArray[i]);
    	}
    	command.Append(")");
    	Excel_OLE_Cmd.CommandText = command.ToString();
    	Excel_OLE_Cmd.ExecuteNonQuery();
    }
