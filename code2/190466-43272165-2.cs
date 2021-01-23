    // Setup session options
    SessionOptions sessionOptions = new SessionOptions
    {
        Protocol = Protocol.Ftp,
        HostName = "host",
        UserName = "user",
        Password = "password",
    };
    // Configure proxy
    sessionOptions.AddRawSettings("ProxyHost", "proxy");
    sessionOptions.AddRawSettings("FtpProxyLogonType", "2");
    sessionOptions.AddRawSettings("ProxyUsername", "proxyuser");
    sessionOptions.AddRawSettings("ProxyPassword", "proxypassword");
    using (Session session = new Session())
    {
        // Connect
        session.Open(sessionOptions);
        // Your code
    }
