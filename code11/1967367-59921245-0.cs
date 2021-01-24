SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM tblUser WHERE Username='" + tb_LoginUsername.Text + 
                "' AND Password='" + tb_LoginPassword.Text + "'", sqlConnection) ;
            /* in above line the program is selecting the whole data from table and the matching it with the user name and password provided by user. */
            DataTable dt = new DataTable(); 
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {
               User.UserID = int.Parse(dt.Rows[0]["UserID"].ToString());
               MainWindow mainWin = new MainWindow();
               mainWin.Show();
               this.Close();
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
removed :
"'UserID='"+User.UserID
