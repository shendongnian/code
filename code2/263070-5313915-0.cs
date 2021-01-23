    public bool tryLogin(string uname, string pword)
    {
        using(MySqlConnection con = new MySqlConnection("host="";user="";password=""; database="";"))
        using(MySqlCommand cmd = new MySqlCommand("SELECT * FROM Staff WHERE username = @name AND password = @pwd;"))
        {
            cmd.Parameters.AddWithValue("@name", uname);
            cmd.Parameters.AddWithValue("@pwd", pword);
            cmd.Connection = con;
            cmd.Connection.Open();            
            using(var reader = cmd.ExecuteReader())
            {
                return reader.Read() && !reader.IsDBNull(0));                
            }
        }
    }
    private void LoginBT_Click(object sender, EventArgs e)
    {
        if (tryLogin(uname.Text, pword.Text))
        {
            using(MySqlConnection con = new MySqlConnection("host="";user="";password=""; database="";"))
            using(MySqlCommand cmd2 = new MySqlCommand("SELECT access_level FROM Staff WHERE username = '" + uname + "';"))
            {
                cmd2.Connection = con;
                cmd2.Connection.Open();                
                
                using(MySqlDataReader reader = cmd2.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        var accessLevel = reader.GetInt32("access_level");
                        switch(accessLevel)
                        {
                            case 1:
                                this.Hide();
                                CarerHomePage CarerHomePage = new CarerHomePage();
                                CarerHomePage.Show();
                                break;
                            case 2:
                                this.Hide();
                                AdministratorHome AdministratorHome = new AdministratorHome();
                                AdministratorHome.Show();
                                break;
                            default:
                                MessageBox.Show("Invalid Login Credentials");
                                break;
                        }
                    }
                }
            }
        }
    }
