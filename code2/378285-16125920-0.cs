    public class WcfDataService1 : DataService< HenryContext >
        {
            // This method is called only once to initialize service-wide policies.
            public static void InitializeService(DataServiceConfiguration config)
    
            {            
                
                  config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
    
                 config.SetServiceOperationAccessRule("*", ServiceOperationRights.All);
                config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V3;
            }
        }
