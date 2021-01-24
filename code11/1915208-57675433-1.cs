    string query2 = $"SHOW TABLES WHERE Tables_in_appdb LIKE '%{tableNamee}%'";
    using (var conn = new MySqlConnection(dbConnectionString))
    {
        conn.Open();
        //using(var cmd1 ) ..)
        using (var cmd2 = new MySqlCommand(query2, conn))
        {
            using (var reader = cmd2.ExecuteReader())
            {
                if (reader.Read())
                {
                    ia.flag = "stop";
                    return false;
                }
                else
                {
                    reader.Close();
                    cmd.ExecuteNonQuery();
                    ia.flag = "continue";
                    return true;
                }
            }
        }
    }
