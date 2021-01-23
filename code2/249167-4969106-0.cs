    // Provide client credentials
    NetworkCredential credentials = new NetworkCredential( "UserName", "RealPasswordHere", "DomainOrMachineName" );
    // Create factory that will be used to create proxy to the service
    // Pass the client credentials into the factory
    var factory = new ChannelFactory<AshService.IDataCollector>( "WSDualHttpBinding_IDataCollector" );
    factory.Credentials.Windows.ClientCredential = credentials;
    // Create and open proxy to the service
    AshService.IDataCollector proxy = factory.CreateChannel();
    ( proxy as IChannel ).Open();
    // Invoke an operation from the service
 
