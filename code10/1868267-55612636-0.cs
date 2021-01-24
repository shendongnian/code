    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);        
    try
    {
        string cmd = "insert into UserLogin values(@UserName, @Password)";
 
        SqlCommand cmd2 = new SqlCommand(cmd, connection);
        cmd2.Parameters.AddWithValue("@UserName", UsernameBox.Text);
        cmd2.Parameters.AddWithValue("@Password", PasswordBox.Text);
        cnn.Open();
        cmd2.ExecuteNonQuery();
