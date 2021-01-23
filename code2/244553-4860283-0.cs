    //Set the system proxy with valid server address or IP and port, for example.
    System.Net.WebProxy pry = new System.Net.WebProxy("172.16.0.1",8080);
    //The DefaultCredentials should be enough.
    pry.Credentials = CredentialCache.DefaultCredentials;
    GlobalProxySelection.Select = pry;
