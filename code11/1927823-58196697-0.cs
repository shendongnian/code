        private void ValidateUser()
        {
            string query = "SELECT role from tbl_login WHERE Username = @username and password=@password";
            string returnValue = "";
            using (SqlConnection con = new SqlConnection("YourConnectionString"))
            {
                using (SqlCommand sqlcmd = new SqlCommand(query, con))
                {
                    sqlcmd.Parameters.Add("@username", SqlDbType.VarChar).Value = tbusername.Text;
                    sqlcmd.Parameters.Add("@password", SqlDbType.VarChar).Value = tbpswlog.Text;
                    con.Open();
                    returnValue = (string)sqlcmd.ExecuteScalar();
                }
            }
            if (String.IsNullOrEmpty(returnValue))
            {
                MessageBox.Show("Incorrect username or password");
            }
            else if (returnValue == "Admin")
            {
                MessageBox.Show("You are logged in as an Admin");
                AdminHome fr1 = new AdminHome();
                fr1.Show();
                this.Hide();
            }
            else if (returnValue=="User")
            {
                MessageBox.Show("You are logged in as a User");
                UserHome fr2 = new UserHome();
                fr2.Show();
                this.Hide();
            }
        }
