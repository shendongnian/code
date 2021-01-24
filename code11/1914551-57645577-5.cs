	private void buttonrestore_Click(object sender, EventArgs e)
	{
		try
		{
			using (SqlConnection restoreConn = new SqlConnection())
			{
				restoreConn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Database=neyadatabase;Integrated Security=True;Connect Timeout=30;";
				restoreConn.Open();
				using (SqlCommand restoredb_executioncomm = new SqlCommand())
				{
					restoredb_executioncomm.Connection = restoreConn;
					restoredb_executioncomm.CommandText = @"RESTORE DATABASE neyadatabase FROM DISK='c:\neyadatabase.bak'";
					restoredb_executioncomm.ExecuteNonQuery();
				}
				restoreConn.Close();
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.ToString());
		}
	}
