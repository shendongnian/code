	private void buttonbackup_Click(object sender, EventArgs e)
	{
		try
		{
			using (SqlConnection dbConn = new SqlConnection())
			{
				 dbConn.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Database=neyadatabase;Integrated Security=True;Connect Timeout=30;";
				 dbConn.Open();
				 using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
				 {
					 multiuser_rollback_dbcomm.Connection = dbConn;
					 multiuser_rollback_dbcomm.CommandText= @"ALTER DATABASE neyadatabase SET MULTI_USER WITH ROLLBACK IMMEDIATE";
					 multiuser_rollback_dbcomm.ExecuteNonQuery();
				 }
				 dbConn.Close();
			}
			SqlConnection.ClearAllPools();
			using (SqlConnection backupConn = new SqlConnection())
			{
				backupConn.ConnectionString = yourConnectionString;
				backupConn.Open();
				using (SqlCommand backupcomm = new SqlCommand())
				{
					backupcomm.Connection = backupConn;
					backupcomm.CommandText= @"BACKUP DATABASE neyadatabase TO DISK='c:\neyadatabase.bak'";
					backupcomm.ExecuteNonQuery();
				}
				backupConn.Close();
			}
	    }
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}  
	}
