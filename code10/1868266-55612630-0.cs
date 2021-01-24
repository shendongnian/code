    string connectionString = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
    using (var con = new SqlConnection(connectionString))
    {
       string query = "insert into UserLogin values(@UserName, @Password)";
       using (var cmd = new SqlCommand(query, con))
       {
          cmd.Parameters.AddWithValue("@UserName", UsernameBox.Text);
          cmd.Parameters.AddWithValue("@Password", PasswordBox.Text);
          con.Open();
          cmd.ExecuteNonQuery();
        }
    }
