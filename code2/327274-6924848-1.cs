    [Conditional("DEBUG")]
    [Obsolete("Please remove me before checkin.")]
    public static void Break()
    {
        #IF DEBUG
        if (Dns.GetHostName() == "PROTECTORONE")
            Debugger.Break();
        #ENDIF
    }
