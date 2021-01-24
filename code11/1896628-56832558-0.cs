    var cmd = new OracleCommand("BEGIN PKG_ENTITY.ALTER_ENTITY(:NAME, :FULLNAME, :ATTRS, :STATUS, :RESULT, :ERRORMSG); END;"), connection);
    cmd.CommandType = CommandType.Text;
    // should work as well
    // var cmd = new SqlCommand("PKG_ENTITY.ALTER_ENTITY(:NAME, :FULLNAME, :ATTRS, :STATUS, :RESULT, :ERRORMSG)"), connection);
    // cmd.CommandType = CommandType.StoredProcedure;
    cmd.Parameters.Add("NAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = "New name"
    cmd.Parameters.Add("FULLNAME", OracleDbType.Varchar2, ParameterDirection.Input).Value = "New fullname"
    par = cmd.Parameters.Add("ATTRS", OracleDbType.Varchar2, ParameterDirection.Input);
    par.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
    var arr string[] = new string[] {"id" , "value"};
    par.Value = arr;
    par.Size = arr .Count;
    cmd.Parameters.Add("STATUS", OracleDbType.Varchar2, ParameterDirection.Input).Value = "Status";
    cmd.Parameters.Add("RESULT", OracleDbType.Int32, ParameterDirection.Output);
    cmd.Parameters("RESULT").DbType = DbType.Int32;
    cmd.Parameters.Add("ERRORMSG", OracleDbType.Varchar2, 100, null, ParameterDirection.Output);
    cmd.Parameters("ERRORMSG").DbType = DbType.String;
    cmd.ExecuteNonQuery();
    var result = System.Convert.ToInt32(cmd.Parameters("RESULT").Value);
    var errmsg = cmd.Parameters("ERRORMSG").Value.ToString();
