                private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Open connection to database...
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query1 = "select * from Your_Table where Title='" + comboBox1.Text + "'";
                command.CommandText = query1;
                OleDbDataReader reader1 = command.ExecuteReader();
                while (reader1.Read())
                {
                    comboBox2.Items.Add(reader1["ColumnName"].ToString());
                }
                connection.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
