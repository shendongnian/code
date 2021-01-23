    OracleParameter[] tmpParans = new OracleParameter[1];
    
    tmpParans[0] = new Oracle.DataAccess.Client.OracleParameter("@User", txtUser.Text);
    
    string tmpQuery = "SELECT COD_USER, PASS FROM TB_USERS WHERE COD_USER = @User";
    
    OracleCommand tmpComand = new OracleCommand(tmpQuery, yourConnection);
    
    tmpComand.Parameters.AddRange(tmpParans);
    
    
    OracleDataReader tmpResult = tmpComand.ExecuteReader(CommandBehavior.SingleRow);
