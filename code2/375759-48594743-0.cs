    var sqlp = new SqlParameter("@param3", my function to get datatable);
    sqlp.SqlDbType = System.Data.SqlDbType.Structured;
    sqlp.TypeName = "dbo.mytypename";
      var v = entitycontext.Database.SqlQuery<bool?>("exec [MyStorProc] @param1,@param2,@param3,@param4", new SqlParameter[]
                        {
                            new SqlParameter("@param1",value here),
                            new SqlParameter("@param2",value here),
                     
                            sqlp,
                            new SqlParameter("@param4",value here)
                        }).FirstOrDefault();
