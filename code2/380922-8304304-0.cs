    string sqlCommand = "schema1.StoredProcName";    
    DbCommand dbCommand = db.GetStoredProcCommand(sqlCommand);
    db.AddInParameter(dbCommand, "@Param1", DbType.Int32, 1);
    db.AddInParameter(dbCommand, "@Param2", DbType.Int32, 2);
    db.ExecuteNonQuery(dbCommand); 
