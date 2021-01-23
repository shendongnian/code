    using(SqlConnection _con = new SqlConnection("your-conn-string-here"))
    using(SqlCommand _cmd = new SqlCommand(queryStmt, _con))
    {
        SqlTransaction sqlTran = _con.BeginTransaction();
        _cmd.Transaction = sqlTran;
        try
        {
           _con.Open();
           // do something, e.g. call _cmd.ExecuteNonQuery, or read a data reader
        
           sqlTran.Commit();
        }
        catch(Exception exc)
        {
            // log error
            sqlTran.Rollback();
        } 
        _con.Close();
    }
