    try
    {
        string connectionString = "datasource=STUFFZ;database=users";
        string select = "SELECT Username, Password FROM RegularUsers WHERE 
            Username = '" + usernameBox.Text + "' AND Password = '" + passwordBox.Text 
            + "'";
    
          MySqlConnection my = new MySqlConnection(connectionString);
    
          MySqlCommand command = new MySqlCommand(select, my);
                my.Open();
    
                //String strResult = String.Empty;
                //strResult = (String)command.ExecuteScalar();
                string[] bba = new string[2];
                bba[1] = (String)command.ExecuteScalar();
                my.Close();
    
    
                if (bba[1].Equals(usernameBox.Text))
                {
                    AdminPanel bb = new AdminPanel();
                    bb.Show();
                }
    }
    catch(Exception ex)
    {
        MessageBox.Show("INCORRECT USER/PASS!");
    }
