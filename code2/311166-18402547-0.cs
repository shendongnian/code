            OleDbConnection conn = new OleDbConnection(MyAccessConn);
            OleDbCommand cmd;
            conn.Open();
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO data([Name],[Surname],[Username],[Password]) VALUES(@Name,@Surname,@Username,@Password)";
                cmd.Parameters.AddWithValue("@Name", name_txt.Text);
                cmd.Parameters.AddWithValue("@Surname", sur_txt.Text);
                cmd.Parameters.AddWithValue("@Username", user_txt.Text);
                cmd.Parameters.AddWithValue("@Password", pwd_txt.Text);
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
