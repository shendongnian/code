	private static void DoSql()
	{
		// Errors of severity level of 10 or less 
		// will NOT bubble up to .Net as an Exception to be caught in the usual way
		const string sql = @"RAISERROR('A test error message of low severity', 10, 1)";
		using (SqlConnection conn = new SqlConnection(myConnString))
		{
			conn.Open();
			// Hook up my listener to the connection message generator
			conn.InfoMessage += new SqlInfoMessageEventHandler(MySqlMessageHandler);
			using (SqlCommand cmd = new SqlCommand(sql, conn))
			{
				cmd.ExecuteNonQuery();
				// code happily carries on to this point
				// despite the sql Level 10 error that happened above
			}
		}
	}
	private static void MySqlMessageHandler(object sender, SqlInfoMessageEventArgs e)
	{
		// This gets all the messages generated during the execution of the SQL, 
		// including low-severity error messages.
		foreach (SqlError err in e.Errors)
		{
			// TODO: Something smarter than this for handling the messages
			MessageBox.Show(err.Message);
		}
	}
