    private void bunifuFlatButton1_Click(object sender, EventArgs e)
    {
        using (MySqlConnection mysqlCon = new MySqlConnection(connectionString))
        {
                                   // Use a named list of fields please. And cleanse the text.
            using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM login.info WHERE username = @user", mysqlCon))
            {
                cmd.Parameters.Add("@user", MySqlDbType.VarChar).Value = username.Text; // Let's hope user name is not Jimmy DropTables!!
                mysqlCon.Open();
    
                using (MySqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        string userhash = rd.GetString("hash");
                        string usersalt = rd.GetString("salt");
    
                        bool isPasswordMatched = VerifyPassword(textpass.Text, userhash, usersalt);
                        // Note that we are passing in strings, not props of an unknown object
                        if (isPasswordMatched)
                        {
                            //Login Successfull
                        }
                        else
                        {
                            //Login Failed
                        }
                    }
                }
    
                mysqlCon.Close();
            }
        }
    }
