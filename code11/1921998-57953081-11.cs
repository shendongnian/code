    using (SqlConnection SQLConn = new SqlConnection(strSQLConn))
    {
    	SQLConn.Open();
    	foreach (var item in checkedListBox1.CheckedItems)
    	{
    		DataRowView row = item as DataRowView;
    		using (SqlCommand SQLCmd = new SqlCommand("select TABLE_NAME, COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE from INFORMATION_SCHEMA.COLUMNS where TABLE_NAME = @tableName ", SQLConn))
    		{
    			SQLCmd.Parameters.AddWithValue("tableName", row["Table_Name"]);
    			using (SqlDataAdapter Da = new SqlDataAdapter(SQLCmd))
    			{
    				DataTable dt = new DataTable();
    				Da.Fill(dt);
    				// rest of the code
    			}
    		}
    	}
    }
