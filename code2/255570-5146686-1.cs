    using (OdbcDataReader Reader = Command.ExecuteReader())
    {
        while (Reader.Read())
        {
            Results.Add(Reader.GetString(0));
        }
        Thread.Sleep(TimeSpan.FromMilliseconds(100));
    }
