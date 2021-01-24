            try
            {
                OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = F:\Database\DBAdatabase.accdb; Persist Security Info = False; ");
                OleDbCommand command = new OleDbCommand("", connection);
                for (int s = 0; s < dataGridView1.Rows.Count - 1; s++)
                {
                    command.Parameters.AddWithValue("@position",dataGridView1.Rows[s].Cells[0].Value);
                    command.Parameters.AddWithValue("@lvPosition",dataGridView1.Rows[s].Cells[1].Value);
                    command.CommandText = "INSERT INTO Quotations (Position, LVPosition) VALUES (@position, @lvPosition)";
                    connection.Open();
                    //this line is not needed as it is set in the command constructor above
                    //command.Connection = connection; 
                    command.ExecuteNonQuery();
                    MessageBox.Show("Data Saved");
                    connection.Close();
                    //edit - this needs to run or you will have duplicate values inserted
                    command.Parameters.Clear(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error   " + ex.Message);
            }
