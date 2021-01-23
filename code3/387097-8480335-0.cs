    using(SqlConnection sqlConn = new sqlConnection(CONNECTION_STRING))
    {
        sqlConn.Open();
        using (SqlTransaction trans = sqlConn.BeginTransaction())
        {
            // execute code and see if rows are affected here
            var query = " ... " ;
            var cmd = new SqlCommand(query, sqlConn);
            var rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0) { ... }
            // roll back the transaction
            trans.RollBack();
        }
        sqlConn.Close();
    }
