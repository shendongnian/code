    void Login_Data(string un, string pw) {
		try {
      
            con = new MySqlConnection(connectionString);
            con.Open();
            Debug.Log("Mysql state: " + con.State);
            string sql = "SELECT * FROM `users` WHERE uname='" + un + "'";
            cmd = new MySqlCommand(sql, con);
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                    if (pw.Equals(rdr[3]))
                    {
                        username = un;
                        MessageBox.Show(username + ", Has Logged in!", "API");
                        usertext.text = "User: " + username;
                        m_uid.text = "UserID: " + rdr.GetString("uid");
                    }
            }
     }
