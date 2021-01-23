    public void sendData(string sqlCommmand) 
    {
        using (var con = new MySqlConnection(ConnectionString))
        using(var cmd = con.CreateCommand()) 
        {
            con.Open();
            cmd.CommandTimeout = 5;
            cmd.CommandText = sqlCommmand;
            cmd.ExecuteNonQuery();
        }
    }
