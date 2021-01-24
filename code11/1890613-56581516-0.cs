    WebServiceClass requestObj= new WebServiceClass ();
    // Fill in your request object
    // Set up the authentication using the function you provided
    var glowsAuthData = PrepareGlowsAuth("expressRateBook");
    WebServiceClassClient client = new WebServiceClassClient (new CustomBinding(glowsAuthData.Item2), glowsAuthData.Item1);
    client.ClientCredentials.UserName.UserName = glowsAuthData.Item3;
    client.ClientCredentials.UserName.Password = glowsAuthData.Item4;
    // Use the client to send the request object and populate the response object
    WebServiceClassResponse responseObj = client.WebServiceClassResponse(requestObj);
