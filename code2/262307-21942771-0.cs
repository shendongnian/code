    using (var da = new MySqlDataAdapter())
    {
        using (da.SelectCommand = conn.CreateCommand())
        {
            da.SelectCommand.CommandText = query;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
    }
