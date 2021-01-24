    string constring = "server=localhost;user=user;pwd=password;database=dbtest;";
    string file = "C:\\backup.sql";
    var fileContent = await Windows.Storage.FileIO.ReadTextAsync(file);
    using (MySqlConnection conn = new MySqlConnection(constring))
    {
        using (MySqlCommand cmd = new MySqlCommand())
        {
            using (MySqlBackup mb = new MySqlBackup(cmd))
            {
                cmd.Connection = conn;
                conn.Open();
                mb.ImportFromString(fileContent);
                conn.Close();
            }
        }
    }
