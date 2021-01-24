    // Configure it as needed, but avoid using `void` with async, as the exceptions in sync and async methods handled differently. 
    // Also, try to make sense here, make the method return the results.
    public async Task CallWebService<T>(WebServiceWRGClient client,  string url, string userName, string password) 
    {
        
        var channelFactory = new ChannelFactory<T>(new BasicHttpBinding(BasicHttpSecurityMode.Transport, new EndpointAddress(url)).CreateChannel(); 
    	var user = new User(); // coming from service reference
    	
        user.UserName = await channelFactory.EncryptValueAsync(userName);
        user.Password = await channelFactory.EncryptValueAsync(password);
        var response  = await client.ClaimSearchAsync(user, "", "", 12345, statuscode.NotSet, "");
    }
