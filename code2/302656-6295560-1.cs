    public void DBMyUpdate(String SqlQuery)
    {
        if (MyConnection.State != ConnectionState.Open)
            MyConnection.Open();
        var cmdUpdate = new SqlCommand();
        cmdUpdate.Connection = MyConnection;
        cmdUpdate.CommandText = SqlQuery;
        cmdUpdate.ExecuteNonQuery(CommandBehavior.CloseConnection);
    }
