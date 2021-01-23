            if (tryLogin(uname.Text, pword.Text) == true)
            {
                using (MySqlConnection con = new MySqlConnection("host="";user="";password=""; database="";"))
                using (MySqlCommand cmd2 = new MySqlCommand("SELECT access_level FROM Staff WHERE username = '" + uname + "';"))
                {
                    cmd2.Connection = con;
                    con.Open();
                    object access_level = cmd2.ExecuteScalar();
                    if (access_level != null && access_level != DBNull.Value)
                    {
                        if (access_level.ToString() == "1")
                        {
                            this.Dispose();
                            CarerHomePage CarerHomePage = new CarerHomePage();
                            CarerHomePage.Show();
                        }
                        else if (access_level.ToString() == "2")
                        {
                            this.Dispose();
                            AdministratorHome AdministratorHome = new AdministratorHome();
                            AdministratorHome.Show();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid Login Credentials");
            }
    }
    }
}
