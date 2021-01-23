    using (SqlConnection conn = (SqlConnection)DataAccessHelper.CreateDatabase().CreateConnection())
    using (DbCommand cmd = new SqlCommand("myProcedure", conn) { CommandType = CommandType.StoredProcedure })
    {
        cmd.Connection.Open();
        using(IDataReader dr = cmd.ExecuteReader())
            doWork(dr);
    }
