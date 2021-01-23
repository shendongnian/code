    string constring = "server=localhost;user=root;pwd=qwerty;database=test;";
    
    // Important Additional Connection Options
    constring += "charset=utf8;convertzerodatetime=true;";
    
    string file = "C:\\backup.sql";
    
    using (MySqlConnection conn = new MySqlConnection(constring))
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            using (MySqlBackup mb = new MySqlBackup(cmd))
            {
                cmd.Connection = conn;
                conn.Open();
                mb.ImportFromFile(file);
                conn.Close();
            }
        }
    }
