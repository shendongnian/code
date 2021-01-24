    public List<Function> GetDeletedFunctions(string connectionString)
    {                        
        string cmdText = @"SELECT * FROM Table "; // dumy query
        return DbHelper.ExecuteQuery<Function>(connectionString,
                                               cmdText,
                                               (SqlDataReader sqlDataReader) =>
                                               {
                                                   var f = (from x in sqlDataReader.Cast<DbDataRecord>()
                                                   select new Function
                                                   {
                                                       Param1 = DbHelper.GetValue<string>("Param1 ", x),
                                                       Param2 = DbHelper.GetValue<string>("Param2", x)
                                                   }).ToList();
    
                                                   return f;
                                               });
    }
