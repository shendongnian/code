    using(DbCommand command = dbConn1.CreateCommand())
    {
        command.CommandText = sql;
        using (var dataReader = command.ExecuteReader())
        {
            dbRows = ToList(dataReader);
        }
        mvarLastSQLError = 0;
    }
                
