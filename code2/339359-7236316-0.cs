    using(var cm = _dbConnection.CreateCommand())
    {
        cm.CommandText = @"Truncate Table dbo.Table";
        cm.CommandType = CommandType.Text;
        cm.ExecuteNonQuery();
    }
