    NetworkProviderCon = new OdbcConnection(strCon);
    NetworkProviderCon.Open();
	
    OdbcCommand NetworkProviderCmd = new OdbcCommand();
    NetworkProviderCmd.CommandText = "{? = SP_NETWORK_IDL(?,?,?)}";
    NetworkProviderCmd.Connection = NetworkProviderCon;
    NetworkProviderCmd.CommandTimeout = this.Variables.CADATABASECORETIMEOUT;
    NetworkProviderCmd.CommandType = CommandType.StoredProcedure;
    //parameters to call SP 
    NetworkProviderCmd.Parameters.Add("pRESULT_CURSOR", OracleType.Cursor).Direction = ParameterDirection.InputOutput; //NetworkProviderParam1
    NetworkProviderCmd.Parameters.Add("pdtStartTime", OdbcType.DateTime).Value = strStartDate; //NetworkProviderParam2
    NetworkProviderCmd.Parameters.Add("pdtEndTime", OdbcType.DateTime).Value = strEndDate; //NetworkProviderParam3
    NetworkProviderCmd.Parameters.Add("RETURN_VALUE", OdbcType.Int).Direction = ParameterDirection.ReturnValue; //NetworkProviderParam4
