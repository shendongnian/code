        // Webservice
        IdentityService ws = new IdentityService();
        // Test Static Credentials
        string username = "twfnf";
        string password = "testme99";
        string domain = "testapps1";
        NetworkCredential credentials = new NetworkCredential(username, password, domain);
        ws.Credentials = credentials;
        ws.PreAuthenticate = true;
        ws.AuthenticateUser();
