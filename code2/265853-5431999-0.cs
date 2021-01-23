    [WebGet(ResponseFormat = WebMessageFormat.Json)] 
    public static void InitializeService(DataServiceConfiguration config)     { 
        config.SetEntitySetAccessRule("*", EntitySetRights.All);   
        config.SetServiceOperationAccessRule("*", ServiceOperationRights.All); 
        config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
     } 
