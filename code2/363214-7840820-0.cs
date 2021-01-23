    string dbfile = "|DataDirectory|\\Databases\\Database.sdf";
    string insertStmt = "insert into Leggers values('" + leggernummer + "','" + omschrijving + "')";
    
    using(SqlCeConnection connection = new SqlCeConnection("Data Source=" + dbfile))
    using(SqlCeCommand query = new SqlCeCommand(insertStmt, connection))
    {
        connection.Open();
        query.BeginExecuteNonQuery();
        connection.Close();
    }
