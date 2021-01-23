		public int GetUserId(string username, string password)
		{
			var sql = @"SELECT * from Users where userName = ?user and password = ?pass";
			DataSet ds = new DataSet();
			MySqlCommand commandWithParams = new MySqlCommand(sql);
			commandWithParams.Parameters.AddWithValue("?user", username);
			commandWithParams.Parameters.AddWithValue("?pass", password);
			MySqlConnection conn = new MySqlConnection("myconn string");
			if (conn.State != ConnectionState.Open)
				conn.Open();
			commandWithParams.Connection = conn;
			
			MySqlDataAdapter da = new MySqlDataAdapter(commandWithParams);
			da.Fill(ds);
			DataTable dt = ds.Tables[0];
			DataRow dr = dt.Rows[0];
			conn.Close();
			conn.Dispose();
			da.Dispose();
			return (int)dr["userId"];
		}
