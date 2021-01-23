    string stconnetionString = "Server=Server name; Port=port number; 
             Database= DB name; Uid=User namw; Pwd=password;";
    MySqlConnection conn = new MySqlConnection(stconnetionString);
           
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
