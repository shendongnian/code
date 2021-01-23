    using (sqlCon = new SqlConnection(connectionString))
    {
        DatabaseHelper helper = new DatabaseHelper(sqlCon);
        helper.BeginTransaction();
        try
        {
            //Sql stuff
            helper.CommitTransaction();
        }
        catch(SqlException)
        {
             helper.RollbackTransaction();
        }
    }
