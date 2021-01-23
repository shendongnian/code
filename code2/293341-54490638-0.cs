    DataSet ds = new DataSet();
    SqlParameter[] p = new SqlParameter[1];
    string Query = "Describe Query Information/either sp, text or TableDirect";
    DbConnectionHelper dbh = new DbConnectionHelper ();
    ds = dbh. DBConnection("Here you use your Table Name", p , string Query, CommandType.StoredProcedure);
