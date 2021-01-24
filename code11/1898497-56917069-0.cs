    try
            {
                using (OleDbConnection connection = new OleDbConnection(connString))
                {
                    OleDbCommand command = new OleDbCommand(queryString, connection);
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        string UName = reader.GetValue(0).ToString();
                        if (UName == UN)
                        {
                            Pass_textBox.Visible = true;
                            Pass_textBox.Enabled = true;
                            SP_checkBox.Visible = true;
                            SP_checkBox.Enabled = true;
                            SP_label.Visible = true;
                            SP_label.Enabled = true;
                            found = 1;                      
                        }
                                       
                    }
                    reader.Close();
                }
                if (found != 1)
                {
                    Pass_textBox.Visible = false;
                    Pass_textBox.Enabled = false;
                    SP_checkBox.Visible = false;
                    SP_checkBox.Enabled = false;
                    SP_label.Visible = false;
                    SP_label.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
