	for (int j = 0; j < DataTableView.Columns.Count - 1; j++)
	{
		try
		{
			sqlCommand.CommandText = @"INSERT INTO TestTable  VALUES (@Value1, @Value2, @Value3)";
			sqlCommand.Connection = sqlConnection;
			
			sqlCommand.Parameters.Clear();
			sqlCommand.Parameters.AddWithValue("@Value1",  DataTableView.Rows[i][j]);
			sqlCommand.Parameters.AddWithValue("@Value2",  DataTableView.Rows[i][j]);
			sqlCommand.Parameters.AddWithValue("@Value3",  DataTableView.Rows[i][j]);
			
			sqlConnection.Open();
			sqlCommand.ExecuteNonQuery();
			sqlConnection.Close();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "Error");
		}
	}
