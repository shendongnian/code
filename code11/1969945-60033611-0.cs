    using(conn = new MySqlConnection(connString)){
        //conn.ConnectionString = connString;
        conn.Open();
        string queryss = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = 'bluevels_local_sis'";
        MySqlCommand cmdaa = new MySqlCommand(queryss, conn);
        //MySqlDataReader dataReaderxx = cmdaa.ExecuteReader();
        //dataReaderxx.Read();
        MessageBox.Show(cmdaa.ExecuteScalar().ToString());
    }
    //conn.Close();
