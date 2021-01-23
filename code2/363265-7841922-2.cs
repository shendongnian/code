    IMyServiceContract client;
    try
    {
        client = Helper.GetFactoryChannel<IMyServiceContract>("http://myserviceaddress");
        client.DoSomething();
 
        // This is another helper method that will safely close the channel, 
        // handling any exceptions that may occurr trying to close.
        // Shouldn't be any, but it doesn't hurt.
        Helper.CloseChannel(client);
    }
    catch (Exception ex)
    {
        // Something went wrong; need to abort the channel
        // I also do logging of some sort here
        Helper.AbortChannel(client);
    }
