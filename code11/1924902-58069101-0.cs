            async void login()
            {
                try
                {
                    using (MySqlConnection connection = new MySqlConnection("-"))
                    {
                        //1st dont store password in plain text
                        //2nd dont use string concat. google sql injection plz
                        using (MySqlCommand cmd = new MySqlCommand("Select COUNT(*) FROM users WHERE username='" + textBox1.Text + "' and password='" + textBox2.Text + "'    ", connection))
                        {
                            connection.Open();
    
                            int count = (int)await cmd.ExecuteScalarAsync();
                            if (count == 1)
                            {
                                //login successful
                                MessageBox.Show("Login success");
                            }
                            else
                            {
                                MessageBox.Show("Login failed");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
