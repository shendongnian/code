		protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
		{
			var sql = @"SELECT * from Users where userName = ?user and password = ?pass";
			DataSet ds = new DataSet();
			MySqlCommand commandWithParams = new MySqlCommand(sql);
			commandWithParams.Parameters.AddWithValue("?user", Login1.UserName);
			commandWithParams.Parameters.AddWithValue("?pass", Login1.Password);
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
			if (dt.Rows.Count != 0)//I'm sure this has a better way
			{
				Session["userId"] = Convert.ToString(dr["userId"]);
				Session["userName"] = Convert.ToString(dr["userName"]);
				e.Authenticated = true;
				Reponse.Redirect("your_page.aspx");
			}
			else
			{
				e.Authenticated = false;
			}
		}
