    using (var context = new DbContext()) // you don't have to strictly use this to reference the context, it's just what i gravitate towards
    {
        var in_Id = new OracleParameter("in_ID", OracleDbType.TYPE, obID, ParameterDirection.Input);
        var in_time = new OracleParameter("in_time", OracleDbType.TYPE, time, ParameterDirection.Input);
        var in_rNo = new OracleParameter("in_rNo", OracleDbType.TYPE, No, ParameterDirection.Input);
    
       await  context.Database.SqlQuery<object>("BEGIN procedurename(:in_Id, :in_time, :in_rNo); END;", in_Id, in_time, in_rNo).ToListAsync();
    
    }
