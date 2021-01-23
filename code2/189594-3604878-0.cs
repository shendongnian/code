    public void Sql_Connection(string queryString)
    {
        using( SqlConnection conn = new SqlConnection(DbConnectionString) )
        {
            SqlCommand cmd = new SqlCommand(queryString, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
