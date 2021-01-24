    private LoginUser validate_login(string user, string pass)
	{
		db_connection();
		MySqlCommand cmd = new MySqlCommand();
		cmd.CommandText = "Select * from table2 where username=@user and password=@pass and UserID=@UserID";
		cmd.Parameters.AddWithValue("@user", user);
		cmd.Parameters.AddWithValue("@pass", pass);
		cmd.Connection = connect;
		LoginUser usr = null;
		MySqlDataReader login = cmd.ExecuteReader();
		if (login.Read())
		{
			usr = new LoginUser();
			usr.UserID = login["UserID"].ToString();
			usr.valid = true;
		}
		return usr;
	}
	private void button1_Click(object sender, EventArgs e)
	{
		{
			string user = usertype.Text;
			string pass = password.Text;
			if (user == "" || pass == "")
			{
				MessageBox.Show("Empty Fields Detected ! Please fill up all the fields");
				return;
			}
			var r = validate_login(user, pass); //problem line
			if (r != null)
			{
				if (r.valid)
				{
					MySqlCommand cmd = new MySqlCommand();
					MySqlDataReader reader = cmd.ExecuteReader();
					Console.WriteLine(String.Format("{0}", r.UserID));
					UserDetails.m_gnUserId = Convert.ToInt32(reader["UserID"]);
				}
			}
		}
	}
