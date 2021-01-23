     try
        {
            string insertData = string.Format("INSERT INTO " + constants.PIZZABROADCASTTABLE + " VALUES(@starttime,@endtime,@lastupdatetime,@applicationname)");
            using (sqlCommand = new SqlCommand(insertData, databaseConnectivity.connection))
			{
				sqlCommand.Parameters.AddWithValue("@starttime", broadcastStartDateTime);
				sqlCommand.Parameters.AddWithValue("@endtime", broadcastEndDateTime);
				sqlCommand.Parameters.AddWithValue("@lastuptime", currentDateTime);
				sqlCommand.Parameters.AddWithValue("@applicationname", txtApplicationName.Text);
				
				sqlCommand.ExecuteNonQuery();
			}
		}
		catch (Exception ex)
		{
			string s = "Failed to insert into table " + constants.PIZZABROADCASTTABLE + "Database Error! " + Environment.NewLine + "Details: " + ex.ToString();
			MessageBox.Show(s, MessageBoxButtons.OK, MessageBoxIcons.Error);
			// Or
			//throw new DatabaseException(s, ex);
		}
		finally
        {
            if (databaseConnectivity != null && databaseConnectivity.connection != null) 
				databaseConnectivity.connection.Close();
			else
				MessageBox.Show("No database connectivity!", "Error", MessageBoxButtons.OK, MessageBoxIcons.Error); 
        }
