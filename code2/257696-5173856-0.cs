    private void loginButton_Click(object sender, EventArgs e)
    {
       string connectionString = "datasource=STUFFZ;database=users";
       string select = "SELECT Username, Password FROM dbo.RegularUsers " + 
                       "WHERE Username = @user AND Password = @Pwd"
    
       using(MySqlConnection myConn = new MySqlConnection(connectionString))
       using(MySqlCommand command = new MySqlCommand(select, myConn))
       { 
           command.Parameters.Add("@user", SqlDbType.VarChar, 50);
           command.Parameters["@user"].Value = usernameBox.Text.Trim();
           command.Parameters.Add("@pwd", SqlDbType.VarChar, 50);
           command.Parameters["@pwd"].Value = passwordBox.Text.Trim();
           myConn.Open();
           using(SqlDataReader rdr = command.ExecuteReader())
           {
              if(rdr.Read())
              {
                 string userName = rdr.GetString(0);
                 string password = rdr.GetString(1);
                 rdr.Close();
              
                 // here compare those values and do whatever you need to do
              }
           }
           myConn.Close();
       }    
    }
