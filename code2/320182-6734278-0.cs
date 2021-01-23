    NetworkProviderCon = new OdbcConnection(strCon);
    NetworkProviderCon.Open();
    NetworkProviderCmd.Connection = NetworkProviderCon;
    NetworkProviderCmd.CommandType = CommandType.StoredProcedure;
    
    NetworkProviderCmd.CommandText = "{? = SP_NETWORK_IDL(?,?,?)}";
    
    NetworkProviderCmd.CommandTimeout = this.Variables.CADATABASECORETIMEOUT;
    //parameters to call SP 
    NetworkProviderParam0 = NetworkProviderCmd.Parameters.Add("pRESULT_CURSOR", OracleType.Cursor);
    NetworkProviderParam0.Direction = ParameterDirection.InputOutput;  
    NetworkProviderParam1 = NetworkProviderCmd.Parameters.Add("pdtStartTime", OdbcType.DateTime);
    NetworkProviderParam1.Value = strStartDate;
    NetworkProviderParam2 = NetworkProviderCmd.Parameters.Add("pdtEndTime", OdbcType.DateTime);
    NetworkProviderParam2.Value = strEndDate;
    
    NetworkProviderParam3 = NetworkProviderCmd.Parameters.Add("RETURN_VALUE", OdbcType.Int); 
    Param3.Direction = ParameterDirection.ReturnValue; 
