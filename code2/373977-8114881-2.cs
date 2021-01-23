        using System.Data.Services;
        using System.Data.Services.Common;
        using DataModel;
        namespace MyDataServiceHost
        {
            public class YourDataService : DataService<YourModelEntities>
            {
                // This method is called only once to initialize service-wide policies.
                public static void InitializeService(DataServiceConfiguration config)
                {
                    // TODO: set rules to indicate which entity sets and service operations are visible, updatable, etc.
                    // Examples:
                    config.SetEntitySetAccessRule("*", EntitySetRights.AllRead);
                    config.DataServiceBehavior.MaxProtocolVersion = DataServiceProtocolVersion.V2;
                }
            }
        }
 
