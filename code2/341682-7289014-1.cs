    //Create using the default endpoint
    UserClient client = new UserClient();
        
            
    //Set user name and password with call
    System.ServiceModel.Description.ClientCredentials loginCredentials = new System.ServiceModel.Description.ClientCredentials();
    loginCredentials.UserName.UserName = "test";
    loginCredentials.UserName.Password = "test";
        
    //Attach Credentials, Can't do this in config file
    var defaultCredentials = client.ChannelFactory.Endpoint.Behaviors.Find<System.ServiceModel.Description.ClientCredentials>();
    client.ChannelFactory.Endpoint.Behaviors.Remove(defaultCredentials);
    client.ChannelFactory.Endpoint.Behaviors.Add(loginCredentials);
    
    //Now make a call to a service method...
