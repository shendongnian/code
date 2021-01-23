            try
            {
                conn.Open();
                MySqlCommand mycmd = conn.CreateCommand();
                mycmd.CommandType = CommandType.Text;
                mycmd.CommandText = "insert into Student(columes name) values(.....)";
                mycmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Saved", "Window Application ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
            catch (Exception)
            {
                throw;
            }
