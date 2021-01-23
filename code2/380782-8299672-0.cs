    string sql = "SELECT * FROM Tigers WHERE Link='" + link + "'";
    using( MySqlCommand cmd = new MySqlCommand(sql, conn) )
    {
        using( MySqlDataReader rdr = cmd.ExecuteReader() )
        {
            while (rdr.Read())
            {
                //found at least 1 result
            }
            if (rdr.RecordsAffected == 0)
            {
                //can't find in db
            }
        }
    }
