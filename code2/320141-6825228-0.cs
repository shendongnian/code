    try
    {
        OracleConnection conn = new OracleConnection("User ID=" + uid + ";Password=" + pwd + ";SERVER=" + server);
        conn.InfoMessage += new OracleInfoMessageEventHandler(GetOracleWarningInfoMessage);        
        conn.Open();
        return ConnectionStatus.OK;
    }
    catch (System.Data.OracleClient.OracleException ex)
    {
        Logger.Error(ex);
        switch (ex.Code)
        {
            case 1005: //null password given
                errmsg = "Invalid password";
                return ConnectionStatus.InvalidUserPwd;
            case 1017: //invalid username/password
                errmsg = "Invalid username/password";
                return ConnectionStatus.InvalidUserPwd;
            case 1040: //invalid character in password
                errmsg = "Invalid password";
                return ConnectionStatus.InvalidUserPwd;
            case 28000://account locked
                errmsg = "Account locked. Contact DBA or wait for PASSWORD_LOCK_TIME";
                return ConnectionStatus.Locked;
            case 28001://password expired                       
                errmsg = "Password expired. Contact DBA";
                return ConnectionStatus.Expired;
            default:
                errmsg = ex.Message;
                return ConnectionStatus.Failed;
        }
    }
