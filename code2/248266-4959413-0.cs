    Michaelis.MockService service = new Michaelis.MockService();
    
    // Create the network credentials and assign
    // them to the service credentials
    NetworkCredential netCredential = new NetworkCredential(“Inigo.Montoya”, “Ykmfptd”);
    Uri uri = new Uri(service.Url);
    ICredentials credentials = netCredential.GetCredential(uri, “Basic”);
    service.Credentials = credentials;
    
    // Be sure to set PreAuthenticate to true or else
    // authentication will not be sent.
    service.PreAuthenticate = true;
    
    // Make the web service call.
    service.Method();
