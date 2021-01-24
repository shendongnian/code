    SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE username = @username AND password = @password", sqlcon);
    
    cmd.Parameters.Add("@username", SqlDbType.VarChar, 100).Value = txtUsername.Text);
    cmd.Parameters.Add("@password", SqlDbType.VarChar, 100).Value = txtPassword.Text;
    // open connection    
    sqlcon.Open();
    // execute reader and iterate over rows
    SqlDataReader dr = cmd.ExecuteReader();
    
    if (dr.HasRows)
    {
        Main objMain = new Main();
        this.Hide();
        objMain.Show();
    }
    else
    {
        MessageBox.Show("Check your username and password");
    }   
    // close connection only **AFTER** you've read the data!
    sqlcon.Close();
