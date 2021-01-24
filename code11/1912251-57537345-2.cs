    BOOLEAN IsRemoteSession;
    
    if (0 > QueryIsRemoteSession(IsRemoteSession))
    {
    	SECURITY_LOGON_TYPE LogonType;
    	if (0 <= GetLogonType(LogonType))
    	{
    		IsRemoteSession = LogonType == RemoteInteractive;
    	}
    }
