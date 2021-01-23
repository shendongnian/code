    try
    { 
        WebServiceClient client = new WebServiceClient();
        client.CallSomeMethod();
    }
    catch(EndpointNotFoundException exc)
    {
       // endpoint not found --> webservice is not up and running
    }
    .....  
    catch(CommunicationException exc)
    {
       // base WCF exception - for things like config errors etc.
    }
