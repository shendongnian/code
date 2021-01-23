    OracleParameter[] orclParams = new OracleParameter[]
    {
        new OracleParameter{
            ParameterName = "param1",
            OracleDbType = OracleDbType.Varchar2,
            Value = "abc" },
        new OracleParameter{
            ParameterName = "param2",
            OracleDbType = OracleDbType.Varchar2,
            Value = "abc" },
        new OracleParameter{
            ParameterName = "date1",
            OracleDbType = OracleDbType.Date,
            Value = myDate }
    };
    SomeFunction(sqlQuery, orclParams.ToList());
