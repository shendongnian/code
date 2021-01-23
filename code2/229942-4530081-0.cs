    string dbfDirectory = @"C:\the_path_to_my_dbf_file_or_files";
    using (OdbcConnection conn = new OdbcConnection(@"Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277;Dbq=" + dbfDirectory + ";"))
    {
        conn.Open();
        using (OdbcCommand cmd = conn.CreateCommand())
        {
            cmd.CommandText = "SELECT * FROM myDbFileFromTheUpperDirectory.dbf";
            using (OdbcDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // do something
                }
            }
        }
    }
