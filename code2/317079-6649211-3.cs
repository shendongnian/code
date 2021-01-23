    SqlConnection conn = null;
    using (conn = (new SqlConnectionManager()).GetSqlConnectionManager())
    {
         //do work with connection
    }
