    public static T ExecuteQuery<T>(string sql, SqlParameter[] parms,
                                    Func<SqlDataReader, T> projection)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        using (SqlCommand command = new SqlCommand(sql, conn) { Parameters = parms })
        {
            conn.Open();
            command.CommandTimeout = 120;
            return projection(command.ExecuteReader());
        }
    }
