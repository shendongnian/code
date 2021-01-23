    public static int ExecuteScalarInt32(string sql, SqlParameter[] parms)
    {
        using (SqlConnection conn = new SqlConnection(ConnectionString))
        using (SqlCommand command = new SqlCommand(sql, conn) { Parameters = parms })
        {
            conn.Open();
            command.CommandTimeout = 120;
            return (int) command.ExecuteScalar();
        }
    }
