    using (Conn = new SqlConnection(Conect)) {
    	try {
    		// Attempt to open data connection
    		Conn.Open();
    		
    		// Compose SQL query
    		string SQL = string.Format("SELECT * FROM MEN WHERE id = '{0}'", txtBAR.Text.Trim());
    		using(SqlCommand command = new SqlCommand(SQL,Conn)) {
    			// Execute query and retrieve buffered results, then close connection when reader
    			// is closed
    			using(SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection)) {
    				// Assign txtFname value to search value and clear value if no results returned
    				txtFname.Text = reader.Read() ? reader[0].ToString() : string.Empty;
    				reader.Close();
    			}
    		}
    	}
    	finally {
    		// Regardless of whether a SQL error occurred, ensure that the data connection closes
    		if (Conn.State != ConnectionState.Closed) {
    			Conn.Close();
    		}
    	}
    }
