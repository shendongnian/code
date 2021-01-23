        EventLogSession session = new EventLogSession(
            "RemoteComputerName",// Remote Computer
            "Domain",// Domain
            "Username",// Username
            pw,
            SessionAuthentication.Default);
