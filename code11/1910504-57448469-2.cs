    SqlCommand cmd = new SqlCommand("SELECT UserId FROM users WHERE username = @username AND password = @password", sqlcon);
    
    cmd.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = txtUsername.Text);
    cmd.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = txtPassword.Text;
    // open connection    
    sqlcon.Open();
    // execute scalar 
    object result = cmd.ExecuteScalar();
    // if we got a result --> user with that username nad password exists
    if (result != null)
    {
        Main objMain = new Main();
        this.Hide();
        objMain.Show();
    }
    else
    {
        MessageBox.Show("Check your username and password");
    }   
    sqlcon.Close();
