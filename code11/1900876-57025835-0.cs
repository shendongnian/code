          MySqlConnection con = null;
            try
            {
                string myConnectionString = "server=localhost;database=test;uid=root;pwd=root;";
               
                    con = new MySqlConnection(myConnectionString);
                    
                    string CmdString = textBox6.Text.ToString();
                    MySqlCommand cmd = new MySqlCommand(CmdString, con);
                     cmd.Parameters.Add("@CusCode", MySqlDbType.VarChar, 50);
                     cmd.Parameters.Add("@STableName", MySqlDbType.VarChar, 50);
                     cmd.Parameters.Add("@Date", MySqlDbType.VarChar, 50);
                     cmd.Parameters.Add("@ModdatZaman", MySqlDbType.VarChar, 50);
                     cmd.Parameters["@CusCode"].Value = myReader["CusCode"].ToString();
                     cmd.Parameters["@STableName"].Value = myReader["STableName"].ToString();
                     cmd.Parameters["@Date"].Value = myReader["Date"].ToString();
                     cmd.Parameters["@ModdatZaman"].Value = myReader["ModdatZaman"].ToString();
                    con.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        MessageBox.Show("Insert Query sucessfully!");
                    }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
