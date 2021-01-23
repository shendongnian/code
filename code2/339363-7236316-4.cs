    using(var cm = _dbConnection.CreateCommand())
    {
        cm.CommandText = @"Truncate Table Table";
        cm.CommandType = CommandType.Text;
        cm.ExecuteNonQuery();
    }
