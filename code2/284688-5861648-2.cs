    public static T ExecuteScalar<T> (this SqlConnection connection, string sql)
    {
        if (connection == null)
        {
            throw new ArgumentNullException("connection");
        }
    
        if (string.IsNullOrEmpty(sql))
        {
            throw new ArgumentNullException("sql");
        }
    
        using(var command = connection.CreateCommand())
        {
            command.CommandText = sql;
            command.CommandType = CommandType.Text;
            return (T)command.ExecuteScalar();
        }
    }
